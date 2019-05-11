using RateIt.Common.Models;
using RateIt.Common.Models.Enums;
using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface IContentPersistanceService
    {
        bool ApplyForContentPersistance(long contentId);
        bool PersistContent(PageContent pageContent, bool liveMode = true);
        bool RunValidationForUser(long userId, long contentId, bool shouldBePersisted);
        IList<PageContent> ConvertRawPageContent(IList<RawPageContent> rawContent);
        PageContent GetPersistedContentByContentId(long contentId);
        IList<PageContent> GetPersistedContentByArticleId(long articleId, int page, int perPage);
        IList<PageContent> GetPersistedContentBySubArticleId(long subArticleId, int page, int perPage);
        EndValidationData GetEndValidationData(long contentId, long userId);
        bool EndValidationEvent(long userId, long contentId, double minThresholdPercent, int maxValidationCount, double amountToSend);
        bool ResetForAnotherRunAtValidation(Content content, IList<UserContentValidation> userValidations, int maxValidationCount);
        void TryToPayUserValidator(IList<UserContentValidation> userValidations, ValidationOutcome outcome, long contentId, long subDirectoryId, long adminId, double amountToSend);
    }
}
