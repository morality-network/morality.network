using AutoMapper;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using RateIt.Common.Models;
using RateIt.Common.Models.Enums;
using RateIt.Model;
using RateIt.Repositories.Interfaces;
using RateIt.Repositories.Repositories;
using RateIt.Services;
using RateIt.Services.Interfaces;
using RateIt.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateItWebApi.App_Start
{
    public static class NinjectWebCommon
    {
        static StandardKernel Kernel;

        static NinjectWebCommon()
        {        
            Kernel = new StandardKernel();
        }

        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(() => CreateKernel());
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
               
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            //Repositories
            kernel.Bind<IRepository<Account>>().To<AccountsRepository>();
            kernel.Bind<IRepository<RateIt.Model.Activity>>().To<ActivitiesRepository>();
            kernel.Bind<ICacheRepository>().To<CacheRepository>();
            kernel.Bind<IRepository<Content>>().To<ContentsRepository>();
            kernel.Bind<IRepository<ContentTransaction>>().To<ContentTransactionsRepository>();
            kernel.Bind<IRepository<RateIt.Model.ContentType>>().To<ContentTypeRepository>();
            kernel.Bind<IRepository<CreditTransaction>>().To<CreditTransactionRepository>();
            kernel.Bind<IRepository<CreditWallet>>().To<CreditWalletsRepository>();
            kernel.Bind<IRepository<RateIt.Model.CrowdfundingCampaign>>().To<CrowdfundingCampaignsRepository>();
            kernel.Bind<IRepository<Currency>>().To<CurrencysRepository>();
            kernel.Bind<IRepository<Investigation>>().To<InvestigationsRepository>();
            kernel.Bind<IRepository<Log>>().To<LogsRepository>();
            kernel.Bind<IMoTokenRepository>().To<MoTokenRepository>();
            kernel.Bind<IRepository<NotificationType>>().To<NotificationTypesRepository>();
            kernel.Bind<IRepository<PaymentChunk>>().To<PaymentChunksRepository>();
            kernel.Bind<IRepository<PaymentTransfer>>().To<PaymentTransferRepository>();
            kernel.Bind<IRepository<PaymentType>>().To<PaymentTypeRepository>();
            kernel.Bind<IRepository<PollAnswer>>().To<PollAnswersRepository>();
            kernel.Bind<IRepository<RateIt.Model.Poll>>().To<PollsRepository>();
            kernel.Bind<IRepository<Rating>>().To<RatingsRepository>();
            kernel.Bind<IRepository<ReportClaim>>().To<ReportClaimsRepository>();
            kernel.Bind<IRepository<ReportConfirm>>().To<ReportConfirmsRepository>();
            kernel.Bind<IRepository<Site>>().To<SitesRepository>();
            kernel.Bind<IRepository<SubDirectory>>().To<SubDirectorysRepository>();
            kernel.Bind<IRepository<RateIt.Model.Survey>>().To<SurveysRepository>();
            kernel.Bind<IRepository<SystemNotification>>().To<SystemNotificationsRepository>();
            kernel.Bind<IRepository<SystemValue>>().To<SystemValuesRepository>();
            kernel.Bind<IRepository<Transaction>>().To<TransactionsRepository>();
            kernel.Bind<IRepository<Upvote>>().To<UpvotesRepository>();
            kernel.Bind<IRepository<UserContentValidation>>().To<UserContentValidationsRepository>();
            kernel.Bind<IRepository<RateIt.Model.UserMessage>>().To<UserMessagesRepository>();
            kernel.Bind<IRepository<UserPollingAnswer>>().To<UserPollingAnswersRepository>();
            kernel.Bind<IRepository<UserRating>>().To<UserRatingsRepository>();
            kernel.Bind<IRepository<WithdrawTransfer>>().To<WithdrawTransfersRepository>();
            kernel.Bind<IRepository<ActivityType>>().To<ActivityTypesRepository>();
            kernel.Bind<IRepository<RateIt.Model.User>>().To<UsersRepository>();
            kernel.Bind<IRepository<RateIt.Model.Comment>>().To<CommentsRepository>();
            kernel.Bind<IRepository<RateIt.Model.Notification>>().To<NotificationsRepository>();

            //Services
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<ICacheService>().To<CacheService>();
            kernel.Bind<ICommentService>().To<CommentService>();
            kernel.Bind<IContentPersistanceService>().To<ContentPersistanceService>();
            kernel.Bind<IContentService>().To<ContentService>();
            kernel.Bind<IContentTypeService>().To<ContentTypeService>();
            kernel.Bind<ICreditTransactionService>().To<CreditTransactionService>();
            kernel.Bind<ICreditWalletService>().To<CreditWalletService>();
            kernel.Bind<ICurrencyService>().To<CurrencyService>();
            kernel.Bind<IInvestigationService>().To<InvestigationService>();
            kernel.Bind<ILoggingService>().To<LoggingService>();
            kernel.Bind<IMiningService>().To<MiningService>();
            kernel.Bind<IMoTokenService>().To<MoTokenService>();
            kernel.Bind<IPaymentService>().To<PaymentService>();
            kernel.Bind<IPaymentTypeService>().To<PaymentTypeService>();
            kernel.Bind<IRatingService>().To<RatingService>();
            kernel.Bind<IReportConfirmService>().To<ReportConfirmService>();
            kernel.Bind<IReportService>().To<ReportService>();
            kernel.Bind<ISiteService>().To<SiteService>();
            kernel.Bind<ISubDirectoryService>().To<SubDirectoryService>();
            kernel.Bind<ISystemValueService>().To<SystemValueService>();
            kernel.Bind<IUpvoteService>().To<UpvoteService>();
            kernel.Bind<IUserMessageService>().To<UserMessageService>();
            kernel.Bind<IUserRatingService>().To<UserRatingService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUserReportService>().To<UserReportService>();
            kernel.Bind<INotificationService>().To<NotificationService>();
            kernel.Bind<IActivityService>().To<ActivityService>();

            //Auto Mapper
            var mapperConfiguration = CreateConfiguration();
            kernel.Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();

            kernel.Bind<IMapper>().ToMethod(ctx =>
                 new Mapper(mapperConfiguration, type => ctx.Kernel.Get(type)));
        }

        private static MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreditTransaction, TransactionResult>()
                    .ForMember(dest => dest.FromUserId, opt => opt.MapFrom(src => src.FromUserId))
                    .ForMember(dest => dest.ToUserId, opt => opt.MapFrom(src => src.ToUserId))
                    .ForMember(dest => dest.PaymentType, opt => opt.MapFrom(src => src.PaymentType.TypeName))
                    .ReverseMap();
                cfg.CreateMap<RateIt.Model.Comment, RateIt.Common.Models.Comment>()
                    .ForMember(dest => dest.SubComments, opt => opt.MapFrom(src => src.Comments1))
                    .ReverseMap();
                cfg.CreateMap<RateIt.Model.User, UserProfile>()
                   .ReverseMap();
                cfg.CreateMap<RateIt.Model.Survey, RateIt.Common.Models.Survey>()
                   .ReverseMap();
                cfg.CreateMap<RateIt.Model.Poll, RateIt.Common.Models.Poll>()
                   .ReverseMap();
                cfg.CreateMap<RateIt.Model.CrowdfundingCampaign, RateIt.Common.Models.CrowdfundingCampaign>()
                   .ReverseMap();
                cfg.CreateMap<RateIt.Model.Content, PageContent>()
                   .ForMember(dest => dest.ContentId, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => (ContentTypeMap)Enum.Parse(typeof(ContentTypeMap), src.ContentType.TypeName)))
                   .ForMember(dest => dest.SiteId, opt => opt.MapFrom(src => src.SubDirectory.SiteId))
                   .ForMember(dest => dest.SubDirectoryId, opt => opt.MapFrom(src => src.SubDirectory.Id))
                   .ForMember(dest => dest.TimestampCreated, opt => opt.MapFrom(src => src.Timestamp))
                   .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comments1.FirstOrDefault()))
                   .ForMember(dest => dest.CrowdFundingCampaigns, opt => opt.MapFrom(src => src.CrowdfundingCampaigns.FirstOrDefault()))
                   .ForMember(dest => dest.Polls, opt => opt.MapFrom(src => src.Polls.FirstOrDefault()))
                   .ForMember(dest => dest.Surveys, opt => opt.MapFrom(src => src.Surveys.FirstOrDefault()))
                   .ReverseMap();
           
            });
            return config;
        }
    }
}