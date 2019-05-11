using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RateIt.Services;
using RateIt.Model;
using RateIt.Services.Interfaces;
using AutoMapper;
using RateItHome.Models;
using RateIt.Common.Models.Enums;

namespace RateItHome.Controllers
{
    [Authorize]
    public class TransactionController : BaseController
    {
        private readonly ICreditTransactionService _creditTransactionService;
        private readonly ICreditWalletService _creditWalletService;
        private readonly ICurrencyService _currencyService;
        private readonly IUserService _userService;
        private readonly ILoggingService _loggingService;
        private readonly IMoTokenService _moTokenService;
        private readonly IMapper _mapper;

        public TransactionController(ICreditTransactionService creditTransactionService, ICreditWalletService creditWalletService,
            ICurrencyService currencyService, IUserService userService, ILoggingService loggingService, IMoTokenService moTokenService,
            IMapper mapper) : base(userService)
        {
            _creditTransactionService = creditTransactionService;
            _currencyService = currencyService;
            _creditWalletService = creditWalletService;
            _userService = userService;
            _loggingService = loggingService;
            _moTokenService = moTokenService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            try
            {
                var user = GetUser();
                var creditWallet = _creditWalletService.GetCreditWalletByUserId(user.Id);
                var creditTransactions = _creditTransactionService.GetTopTransactionsForUser(user.Id, 5, 0);
                var transactions = _moTokenService.GetTransactonEvents(user.Id, TransactionFilter.None, 5, 0);
                var model = new TransactionViewModel()
                {
                    Transactions = transactions,
                    CreditTransactions = creditTransactions,
                    CreditWallet = creditWallet
                };
            }
            catch (Exception ex)
            {
                _loggingService.Log(ex.StackTrace);
            }
            return View(new TransactionViewModel());
        }

        public bool TransferMoCredit(long to, double amount)
        {
            try
            {
                var user = GetUser();
                var addedAmount = _creditWalletService.Transfer(user.Id, to, amount);
                if (addedAmount)
                {
                    var addedTransaction = _creditTransactionService.AddMoCreditsTransaction(to, user.Id,
                            amount, TransferType.StraightTransfer, null);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _loggingService.Log(ex.StackTrace);
                return false;
            }
        }

    }
}