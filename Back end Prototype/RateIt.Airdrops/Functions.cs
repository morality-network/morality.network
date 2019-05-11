using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using RateIt.Model;
using RateIt.Services;
using RateIt.Repositories.Repositories;
using RateIt.Utilities;

namespace RateIt.Airdrops
{
    public class Functions
    {
        //Run Every Day - Set on the portal
        [NoAutomaticTrigger]
        public static void AutoPay()
        {
            //Setup entities and logging repo/service
            var entities = new MoralityNetworkEntities();
            var logRepository = new LogsRepository(entities);
            var loggingService = new LoggingService(logRepository);

            //Encapsulate the rest in try/catch
            try
            {
                //Repositoies
                var userRepository = new UsersRepository(entities);
                var userRatingRepository = new UserRatingsRepository(entities);
                var userReportRepository = new ReportClaimsRepository(entities);
                var creditTransactionRepository = new CreditTransactionRepository(entities);
                var creditWalletRepository = new CreditWalletsRepository(entities);
                var paymentTypeRepository = new PaymentTypeRepository(entities);
                var systemValueRepository = new SystemValuesRepository(entities);
                var accountRepository = new AccountsRepository(entities);
                var userMessageRepository = new UserMessagesRepository(entities);

                //Services
                var userRatingService = new UserRatingService(userRatingRepository);
                var userReportService = new UserReportService(userReportRepository);
                var userService = new UserService(userRepository, userRatingService, userReportService);
                var paymentTypesService = new PaymentTypeService(paymentTypeRepository);
                var creditTransactionService = new CreditTransactionService(creditTransactionRepository, creditWalletRepository,
                    paymentTypesService);
                var systemValueService = new SystemValueService(systemValueRepository);
                var accountService = new AccountService(accountRepository);
                var creditWalletService = new CreditWalletService(creditWalletRepository, accountService, creditTransactionService,
                    systemValueService);
                var userMessageService = new UserMessageService(userMessageRepository);

                //Action
                var paymentService = new PaymentService(userService, creditTransactionService,
                        creditWalletService, userMessageService, systemValueService);
                paymentService.MakeRandomMoCPayment(TimeSpanUtilities.GetLast3Months());
            }
            catch (Exception ex)
            {
                loggingService.Log(ex.StackTrace);
            }
        }
    }
}
