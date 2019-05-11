using AutoMapper;
using Microsoft.ApplicationInsights;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using RateIt.Common.Models;
using RateIt.Common.Models.Enums;
using RateIt.Model;
using RateIt.Services.Interfaces;
using RateIt.Utilities;
using RateItWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Http;


namespace RateItWebApi.Controllers
{

    [RoutePrefix("api/comments")]
    public class CommentController : BaseController
    {
        private const int PerPage = 30;
        private readonly ICommentService _commentService;
        private readonly ILoggingService _loggingService;
        private readonly ISubDirectoryService _subDirectoryService;
        private readonly IUserService _userService;

        public CommentController(ICommentService commentService, ISubDirectoryService subDirectoryService,
            ILoggingService loggingService, IUserService userService, IMapper mapper) : base(mapper)
        {
            _commentService = commentService;
            _loggingService = loggingService;
            _subDirectoryService = subDirectoryService;
            _userService = userService;
        }

        [MoralityAuthenticationFilter]
        [Route("get")]
        [HttpGet]
        public IList<RateIt.Common.Models.Comment> GetComments(CommentModel model)
        {
            try
            {
                var decodedUrl = HttpUtility.UrlDecode(model.EncodedUrl);
                var subDirectory = _subDirectoryService.FindOrInsertSite(decodedUrl);
                var comments = _commentService.GetCommentsBySubDirectory(subDirectory.Id, model.Page, PerPage, model.SearchTerm);
                return _mapper.Map<IList<RateIt.Common.Models.Comment>>(comments);
            }
            catch (Exception ex)
            { 
                _loggingService.Log(ex.StackTrace);
                return null;
            }
        }

        [MoralityAuthenticationFilter]
        [Route("add")]
        [HttpPost]
        public bool CreateComment([FromBody]CreateCommentModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return false;
                var user = _userService.GetUserByEmail(User.Identity.Name);
                var decodedUrl = HttpUtility.UrlDecode(model.EncodedUrl);
                var addedComment = _commentService.AddComment(decodedUrl, model.Content, user.Id, model.ParentId);
                if (addedComment != null)
                {
                    _commentService.AddCommentNotificationsAndActivity(model.ParentId, addedComment.ContentId,
                        addedComment.Content1.SubDirectoryId, user);
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

        [MoralityAuthenticationFilter]
        [Route("vote")]
        [HttpPost]
        public bool VoteForComment([FromBody] CommentUpvoteModel model)
        {
            try {
                if (!ModelState.IsValid)
                    return false;
                var direction = model.Upvote ? Direction.Up : Direction.Down;
                var user = _userService.GetUserByEmail(User.Identity.Name);
                var voted = _commentService.RateCommentUpDown(user.Id, model.CommentId, direction);
                if (voted)
                {
                    _commentService.AddCommentVoteNotificationsAndActivity(model.CommentId, user);
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

        [MoralityAuthenticationFilter]
        [Route("tip")]
        [HttpPost]
        public bool TipComment([FromBody] CommentTipModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return false;
                var user = _userService.GetUserByEmail(User.Identity.Name);
                var tipped = _commentService.TipComment(user.Id, model.CommentId, model.Amount);
                if (tipped)
                {
                    _commentService.AddCommentTipNotificationsAndActivity(model.CommentId, user);
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
