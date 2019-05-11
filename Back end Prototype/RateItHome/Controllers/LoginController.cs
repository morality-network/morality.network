using RateItHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RateItHome.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index(LoginViewModel model)
        {
            string name =System.Web.HttpContext.Current.User.Identity.Name;
            var signedIn = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (signedIn)
                return RedirectToAction("Index", "Dashboard", new { });
            else
            {
                if (model == null)
                    model = new LoginViewModel(){ RememberMe = false };
                return View("Login", model);
            }
        }    
    }
}