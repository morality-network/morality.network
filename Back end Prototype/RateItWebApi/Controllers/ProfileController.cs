using AutoMapper;
using RateIt.Common.Models;
using RateIt.Services.Interfaces;
using RateItWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RateItWebApi.Controllers
{
    [RoutePrefix("api/profile")]
    public class ProfileController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ILoggingService _loggingService;

        public ProfileController(IMapper mapper, IUserService userService, ILoggingService loggingService) : base(mapper)
        {
            _userService = userService;
            _loggingService = loggingService;
        }

        [MoralityAuthenticationFilter]
        [Route("get")]
        [HttpGet]
        public UserProfile GetUserProfile()
        {
            try
            {
                var user = _userService.GetUserByEmail(User.Identity.Name);
                return _mapper.Map<UserProfile>(user);
            }
            catch (Exception ex)
            {
                _loggingService.Log(ex.StackTrace);
                return null;
            }
        }

        [MoralityAuthenticationFilter]
        [Route("update")]
        [HttpPost]
        public UserProfile UpdateUserProfile([FromBody]UserModel model)
        {
            try
            {
                if (!ModelState.IsValid) return null;
                var user = _userService.GetUserByEmail(User.Identity.Name);
                var updated = _userService.UpdateUserInfo(user.Id, model.Bio, model.FullName, model.ProfilePictureUrl);
                if (updated)
                    user = _userService.GetUserByEmail(User.Identity.Name);
                return _mapper.Map<UserProfile>(user);
            }
            catch (Exception ex)
            {
                _loggingService.Log(ex.StackTrace);
                return null;
            }
        }

        [MoralityAuthenticationFilter]
        [Route("deactivate")]
        [HttpPost]
        public bool DeactivateUserProfile()
        {
            try
            {
                var user = _userService.GetUserByEmail(User.Identity.Name);
                return _userService.DeactivateUser(user.Id);
            }
            catch (Exception ex)
            {
                _loggingService.Log(ex.StackTrace);
                return false;
            }
        }

    }
}
