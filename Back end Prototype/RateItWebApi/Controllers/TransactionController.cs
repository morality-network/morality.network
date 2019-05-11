using AutoMapper;
using RateIt.Common.Models;
using RateIt.Common.Models.Enums;
using RateIt.Services.Interfaces;
using RateItWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace RateItWebApi.Controllers
{
    [RoutePrefix("api/transaction")]
    public class TransactionController : BaseController
    {
        private readonly ICreditTransactionService _creditTransactionService;
        private readonly IUserService _userService;
        private readonly ILoggingService _loggingService;

        public TransactionController(ICreditTransactionService creditTransactionService, IUserService userService,
            ILoggingService loggingService, IMapper _mapper) : base(_mapper)
        {
            _creditTransactionService = creditTransactionService;
            _userService = userService;
            _loggingService = loggingService;
        }

        [MoralityAuthenticationFilter]
        [Route("create")]
        [HttpPost]
        public bool CreateTransaction([FromBody]TransactionModel model)
        {
            try
            {
                if (!ModelState.IsValid) return false;
                var user = _userService.GetUserByEmail(User.Identity.Name);
                if (user.Id != model.UserFromId) return false;
                return _creditTransactionService.AddMoCreditsTransaction(model.UserToId, user.Id, model.AmountToSend,
                    TransferType.StraightTransfer, null);
            }
            catch (Exception ex)
            {
                _loggingService.Log(ex.StackTrace);
                return false;
            }
        }

        [MoralityAuthenticationFilter]
        [Route("list/inbound")]
        public IList<TransactionResult> GetInboundUserTransactions(PageModel pageModel)
        {
            try
            {
                var user = _userService.GetUserByEmail(User.Identity.Name);
                if (user != null)
                {
                    var rawTransactions = _creditTransactionService
                        .GetTopTransactionsToUser(user.Id, pageModel.PerPage, pageModel.PerPage * pageModel.PageNum);
                    return _mapper.Map<IList<TransactionResult>>(rawTransactions);
                }
                return null;
            }
            catch (Exception ex)
            {
                _loggingService.Log(ex.StackTrace);
                return null;
            }
        }

        [MoralityAuthenticationFilter]
        [Route("list/outbound")]
        public IList<TransactionResult> GetOutboundUserTransactions(PageModel pageModel)
        {
            try
            {
                var user = _userService.GetUserByEmail(User.Identity.Name);
                if (user != null)
                {
                    var rawTransactions = _creditTransactionService
                        .GetTopTransactionsFromUser(user.Id, pageModel.PerPage, pageModel.PerPage * pageModel.PageNum);
                    return _mapper.Map<IList<TransactionResult>>(rawTransactions);
                }
                return null;
            }
            catch (Exception ex)
            {
                _loggingService.Log(ex.StackTrace);
                return null;
            }
        }
    }
}
