using AutoMapper;
using RateIt.Model;
using RateIt.Services.Interfaces;
using RateItWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RateItWebApi.Controllers
{
    [RoutePrefix("api/report/claim")]
    public class ReportClaimController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IReportService _reportService;
        private readonly ICommentService _commentService;
        private readonly ILoggingService _loggingService;

        public ReportClaimController(IMapper mapper, IUserService userService, IReportService reportService,
            ICommentService commentService, ILoggingService loggingService) :base(mapper)
        {
            _userService = userService;
            _reportService = reportService;
            _commentService = commentService;
            _loggingService = loggingService;
        }
     
        [MoralityAuthenticationFilter]
        [HttpPost]
        [Route("comment")]
        public bool ReportComment(ReportClaimModel model)
        {
            try
            {
                var user = _userService.GetUserByEmail(User.Identity.Name);
                if (user != null)
                {
                    return _reportService.ReportComment(user.Id, model.CommentId);
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