using RateIt.Common.Models.Enums;
using RateIt.Model;
using RateIt.Repositories.Interfaces;
using RateIt.Services.Interfaces;
using RateIt.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUserService _userService;
        private readonly ICreditTransactionService _creditTransactionService;
        private readonly ICreditWalletService _creditWalletService;
        private readonly IUserMessageService _userMessageService;
        private readonly ISystemValueService _systemValueService;
       
        public PaymentService(IUserService userService, ICreditTransactionService creditTransactionService,
            ICreditWalletService creditWalletService, IUserMessageService userMessageService, ISystemValueService systemValueService) {
            _userService = userService;
            _creditTransactionService = creditTransactionService;
            _creditWalletService = creditWalletService;
            _userMessageService = userMessageService;
            _systemValueService = systemValueService;
        }

        public bool MakeRandomMoCPayment(Utilities.TimeSpan timeSpan)
        {
            var systemValues = _systemValueService.GetNewestSystemValue();
            var totalUserCount = _userService.GetAllUsersCount(timeSpan);

            //If the amount of users (as of now) is greater than the min threshold 
            if (totalUserCount > systemValues.AirdropTotalUserCountMinThreshold)
            {
                Random rnd = new Random();
                //Get a random percent payout 10~20
                int giveAway = rnd.Next(systemValues.AirdropMinThresholdUserPercent, systemValues.AirdropMaxThresholdUserPercent);
                //Get the number of users based on the random percentage > and round up
                double usersToGiveAway = Math.Ceiling(
                    ((double)(totalUserCount) / 100.0) * ((double)giveAway)
                );
                var randomUsers = _userService.GetRandomUsers(((int)usersToGiveAway), timeSpan.StartDate);

                foreach (var user in randomUsers)
                {
                    var amount = NumberUtility.GetRandomDouble(10, 100);
                    //Make transfer from admin account
                    var success = _creditWalletService.Transfer(systemValues.AdminUserId, user.Id, amount, TransferType.Airdrop);
                    if (success)
                    {
                        //Send message to user informing of success
                        _userMessageService.AddUserMessage($@"You have been randomly selected to recieve: {amount} MoC!", 
                            user.Id, MessageStatus.Win.ToString());
                    }
                }
                return true;
            }
            return false;
        }

    }
}
