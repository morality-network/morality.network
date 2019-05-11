using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using RateIt.Utilities;
using RateIt.Services.Interfaces;
using RateIt.Repositories.Interfaces;
using RateIt.Common.Models.Enums;

namespace RateIt.Services
{
    public class CreditWalletService : ICreditWalletService
    {
        private readonly IRepository<CreditWallet> _creditWalletRepository;
        private readonly IAccountService _accountService;
        private readonly ICreditTransactionService _creditTransactionService;
        private readonly ISystemValueService _systemValueService;

        public CreditWalletService(IRepository<CreditWallet> creditWalletRepository, IAccountService accountService,
            ICreditTransactionService creditTransactionService, ISystemValueService systemValueService)
        {
            _creditWalletRepository = creditWalletRepository;
            _accountService = accountService;
            _creditTransactionService = creditTransactionService;
            _systemValueService = systemValueService;
        }

        public CreditWallet GetCreditWalletByUserId(long userId)
        {
            var userAccount = _accountService.GetAccountForUser(userId);
            if (userAccount != null)
                return _creditWalletRepository.GetAll()
                     .FirstOrDefault(x => x.Account?.User?.Id == userId);
            return null;
        }

        public CreditWallet CreateWalletByAccountId(long accountId)
        {
            return _creditWalletRepository.GetAll()
                .FirstOrDefault(x => x.Account.Id == accountId);
        }

        public bool Transfer(long from, long to, double amount)
        {
            return Transfer(from, to, amount, TransferType.StraightTransfer);
        }

        public bool Transfer(long from, long to, double amount, TransferType type)
        {
            var wallet = GetCreditWalletByUserId(from);
            var toWallet = GetCreditWalletByUserId(to);
            if ((wallet != null) && (toWallet != null))
            {
                //Take money from the from wallet
                var walletMinusAmount = wallet.CurrentAmount - amount;
                if (walletMinusAmount < 0)
                    return false;
                //Continue if is updated
                var hasUpdatedFromWallet = UpdateWallet(wallet);
                if (hasUpdatedFromWallet)
                {
                    //Add transaction record for the from 
                    _creditTransactionService.AddMoCreditsTransaction(to, from, amount, type, null);
                    //Add money to the to wallet
                    toWallet.CurrentAmount += amount;
                    var hasUpdatedToWallet = UpdateWallet(toWallet);
                    //Add transaction record to the to
                    if(hasUpdatedToWallet)
                        _creditTransactionService.AddMoCreditsTransaction(to, from, amount, type, null);
                    return true;
                }
            }
            return false;
        }

        public bool UpdateWallet(CreditWallet wallet)
        {
            if(wallet != null)
            {
                _creditWalletRepository.Update(wallet);
                var hasAdded = Convert.ToBoolean(_creditWalletRepository.Save());
                if (hasAdded) return true;
            }
            return false;
        }

        public bool PayIntoWallets(IList<User> users, double amountToPay)
        {
            if(users!=null && users.Any())
            {
                var systemValues = _systemValueService.GetNewestSystemValue();
                var adminId = systemValues.AdminUserId;
                var amountToSend = systemValues.AmountToPayForTraining;
                foreach (var user in users)
                {
                    Transfer(adminId, user.Id, amountToSend);
                }
                return true;
            }
            return false;
        }
    }
}
