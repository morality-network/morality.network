using RateIt.Model;
using RateIt.Services.Interfaces;
using RateItHome.Models;
using RateItRepository;
using RateItRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RateItHome.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUserService _userRepository;

        public BaseController(IUserService userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUser()
        {
            var identity = System.Web.HttpContext.Current.User.Identity;
            var user = _userRepository.GetUserByEmail(identity.Name);
            return user;
        }
    }
}