using AutoMapper;
using Microsoft.AspNet.Identity;
using RateIt.Model;
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
    [RoutePrefix("api/rating")]
    public class RatingController : BaseController
    {
        private readonly IRatingService _ratingService;
        private readonly ISubDirectoryService _subDirectoryService;
        private readonly ILoggingService _loggingService;
        private readonly IUserService _userService;

        public RatingController(IRatingService ratingService, ISubDirectoryService subDirectoryService,
            ILoggingService loggingService, IUserService userService, IMapper mapper):base(mapper)
        {
            _ratingService = ratingService;
            _subDirectoryService = subDirectoryService;
            _loggingService = loggingService;
            _userService = userService;
        }

        [MoralityAuthenticationFilter]
        [Route("get")]
        [HttpGet]
        public double GetRating()
        {
            try
            {
                var url = GetAbsoluteUrlOfCaller();
                var subDirectory = _subDirectoryService.FindOrInsertSite(url);
                var rating = _ratingService.GetRatingBySubDirectoryId(subDirectory.Id);
                return rating.RatingValue;
            }
            catch (Exception ex)
            {
                _loggingService.Log(ex.StackTrace);
                return 0.0;
            }
        }

        [MoralityAuthenticationFilter]
        [Route("add")]
        [HttpPost]
        public bool AddRating([FromBody]RatingModel model)
        {
            try
            {
                User user = _userService.GetUserByEmail(User.Identity.Name);
                if (user != null)
                {
                    var url = GetAbsoluteUrlOfCaller();
                    return _ratingService.AddRating(user.Id, url, model.Rating);
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
