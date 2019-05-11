using AutoMapper;
using RateIt.Common.Models;
using RateIt.Common.Models.Enums;
using RateIt.Model;
using RateIt.Repositories.Interfaces;
using RateIt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace RateIt.Services
{
    public class ContentPersistanceService : IContentPersistanceService
    {
        private readonly IContentService _contentService;
        private readonly IUserService _userService;
        private readonly ICurrencyService _currencyService;
        private readonly IMoTokenService _moTokenService;
        private readonly IRepository<ContentTransaction> _contentTransactionRepository;
        private readonly IUserContentValidationService _userContentValidationService;
        private readonly ISystemValueService _systemValuesService;
        private readonly ICreditTransactionService _transactionService;
        private readonly IActivityService _activityService;
        private readonly INotificationService _notificationService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public ContentPersistanceService(IContentService contentService, IUserService userService, ICurrencyService currencyService,
            IMoTokenService moTokenService, IRepository<ContentTransaction> contentTransactionRepository,
            IUserContentValidationService userContentValidationService, ISystemValueService systemValuesService,
            ICreditTransactionService transactionService, IActivityService activityService, IAccountService accountService,
            INotificationService notificationService, IMapper mapper)
        {
            _contentService = contentService;
            _systemValuesService = systemValuesService;
            _userService = userService;
            _currencyService = currencyService;
            _moTokenService = moTokenService;
            _userContentValidationService = userContentValidationService;
            _contentTransactionRepository = contentTransactionRepository;
            _transactionService = transactionService;
            _activityService = activityService;
            _notificationService = notificationService;
            _accountService = accountService;
            _mapper = mapper;
        }

        public bool ApplyForContentPersistance(long contentId)
        {
            var content = _contentService.GetContentById(contentId);
            if (content!= null && !content.ExistsOnBlockChain && !content.AppliedForPersistence && !content.EligableForPersistance)
            {
                content.AppliedForPersistence = true;
                content.AppliedForPersistencedAt = DateTime.Now;
                return _contentService.UpdateContent(content);
            }
            return false;
        }

        public bool PersistContent(PageContent pageContent, bool liveMode = true)
        {
            var content = _contentService.GetContentById(pageContent.ContentId);
            if (content != null && !content.ExistsOnBlockChain && content.AppliedForPersistence && content.EligableForPersistance)
            {
                //Add to blockchain
                var currency = liveMode ? _currencyService.GetLiveCurrency() : _currencyService.GetTestCurrency();
                if (currency != null)
                {
                    var contentTransactionHash = _moTokenService.AddContentToBlockChain(pageContent);
                    if (!string.IsNullOrEmpty(contentTransactionHash))
                    {
                        _contentTransactionRepository.Add(new ContentTransaction()
                        {
                            ContentId = content.Id,
                            TransactionHash = contentTransactionHash,
                            Timestamp = DateTime.Now
                        });
                        return true;
                    }
                }
            }
            return false;
        }

        public bool RunValidationForUser(long userId, long contentId, bool shouldBePersisted)
        {
            var contentToPersist = _contentService.GetContentById(contentId);
            var userValidationExists = _userContentValidationService.HasUserValidatedAlready(userId, contentId);
            var systemValues = _systemValuesService.GetNewestSystemValue();
            if (systemValues != null && contentToPersist != null && !userValidationExists)
            {
                var persistCount = _userContentValidationService.GetValidationsForContent(contentId, true)
                    .Count();
                if (contentToPersist.AppliedForPersistence == true && contentToPersist.EligableForPersistanceAt != null
                    && persistCount < systemValues.ValidationUserMaxCount && !contentToPersist.ReferredViaValidationToAdmin)
                {
                    var validated = _userContentValidationService.AddValidationRecord(userId, contentId, shouldBePersisted);
                    if (validated)
                    {
                        _activityService.AddActivity(ActivityTypeMap.ValidatedContent, contentId, userId, contentToPersist.SubDirectoryId);
                        if (persistCount >= systemValues.ValidationUserMaxCount)
                            EndValidationEvent(userId, contentId, systemValues.ValidationUserThresholdPercent, 
                                systemValues.ValidationUserMaxRunCount, systemValues.AmountToPayForUserValidation);
                        return true;
                    }
                }
            }
            return false;
        }

        public EndValidationData GetEndValidationData(long contentId, long userId)
        {
            var userValidations = _userContentValidationService.GetValidationsForContent(contentId, true);
            var userValidation = userValidations.FirstOrDefault(x => x.UserId == userId);
            var totalValues = (double)userValidations.Count();
            var forValues = (double)userValidations.Count(x => x.ShouldBePersisted);
            var forPercent = ((forValues / totalValues) * 100);
            var againstValues = (double)userValidations.Count(x => !x.ShouldBePersisted);
            var againstPercent = ((againstValues / totalValues) * 100);
            var admin = _accountService.GetAdminAccount();
            return new EndValidationData()
            {
                Admin = admin,
                AgainstPercent = againstPercent,
                AgainstValues = againstValues,
                ForPercent = forPercent,
                ForValues = forValues,
                TotalValues = totalValues,
                UserValidation = userValidation,
                UserValidations = userValidations
            };
        }

        public bool EndValidationEvent(long userId, long contentId, double minThresholdPercent, 
            int maxValidationCount, double amountToSend)
        {
            var content = _contentService.GetContentById(contentId);
            if (content != null)
            {
                var endValidationData = GetEndValidationData(contentId, userId);
                if (endValidationData.ForPercent >= minThresholdPercent)
                {
                    //Try to pay successful users
                    TryToPayUserValidator(endValidationData.UserValidations, ValidationOutcome.Keep, contentId, content.SubDirectoryId,
                            endValidationData.Admin.Id, amountToSend);
                    //Add content
                    PersistContent(_mapper.Map<PageContent>(content));
                }
                else if (endValidationData.AgainstPercent >= minThresholdPercent)
                {
                    //Try to pay successful users
                    TryToPayUserValidator(endValidationData.UserValidations, ValidationOutcome.Remove, contentId, content.SubDirectoryId,
                            endValidationData.Admin.Id, amountToSend);
                    //Add content
                    PersistContent(_mapper.Map<PageContent>(content));
                }
                else
                {
                    ResetForAnotherRunAtValidation(content, endValidationData.UserValidations, maxValidationCount);
                    return true;
                }
            }
            return false;
        }

        public bool ResetForAnotherRunAtValidation(Content content, IList<UserContentValidation> userValidations, int maxValidationCount)
        {
            content.ValidationRunCount = content.ValidationRunCount + 1;
            //If we have reached max network runs then refer to us
            if (content.ValidationRunCount == maxValidationCount)
                content.ReferredViaValidationToAdmin = true;
            var updated = _contentService.UpdateContent(content);
            //Deactivate all and increase count.
            var deactivated = _userContentValidationService.DeactivateAllValidationsForContent(content.Id);
            var userIds = userValidations.Select(x => x.UserId)
                .ToList();
            //Notify all about validation
            var notified = _notificationService.NotifyAllUserValidators("A concensus was not met for content you voted on. No payments have been made.", 
                userIds, content.Id, content.SubDirectoryId);
            if (updated && deactivated && notified)
                return true;
            return false;
        }

        public void TryToPayUserValidator(IList<UserContentValidation> userValidations, ValidationOutcome outcome, long contentId, long subDirectoryId, 
            long adminId, double amountToSend)
        {
            //Pay the people
            foreach (var validator in userValidations)
            {
                if (validator.ShouldBePersisted && outcome == ValidationOutcome.Keep ||
                    !validator.ShouldBePersisted && outcome == ValidationOutcome.Remove)
                {
                    _transactionService.AddMoCreditsTransaction(validator.UserId, adminId,
                        amountToSend, TransferType.LinkedContentValidation, contentId);
                    _notificationService.NotifyAllUserValidators($"You got paid {amountToSend}mo for your participation in a validation. Well done, you were part of the concensus",
                        new List<long>() { validator.UserId }, contentId, subDirectoryId);
                }
                else
                    _notificationService.NotifyAllUserValidators($"Unfortunatly you were not part of the concensus for a user validation you participated in. Better luck next time",
                       new List<long>() { validator.UserId }, contentId, subDirectoryId);
            }
        }

        public IList<PageContent> ConvertRawPageContent(IList<RawPageContent> rawContent)
        {
            var serializer = new JavaScriptSerializer();
            var pageContent = new List<PageContent>();
            foreach (var contentItem in rawContent)
            {
                var content = serializer.Deserialize<PageContent>(contentItem.Data);
                pageContent.Add(content);
            }
            return pageContent;
        }

        public PageContent GetPersistedContentByContentId(long contentId)
        {
            var rawContent = _moTokenService.GetExactContent(contentId);
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<PageContent>(rawContent.Data);
        }

        public IList<PageContent> GetPersistedContentByArticleId(long articleId, int page, int perPage)
        {
            var rawContent = _moTokenService.GetContentByArticleId(articleId);
            rawContent = rawContent.OrderBy(x => x.Timestamp)
                .Skip(page*perPage)
                .Take(perPage)
                .ToList();
            return ConvertRawPageContent(rawContent);
        }

        public IList<PageContent> GetPersistedContentBySubArticleId(long subArticleId, int page, int perPage)
        {
            var rawContent = _moTokenService.GetContentBySubArticleId(subArticleId);
            rawContent = rawContent.OrderBy(x => x.Timestamp)
                .Skip(page * perPage)
                .Take(perPage)
                .ToList();
            return ConvertRawPageContent(rawContent);
        }
    }
}
