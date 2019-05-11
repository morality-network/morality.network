using AutoMapper;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using RateIt.Model;
using RateIt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace RateItWebApi.Controllers
{
    public class BaseController : ApiController
    {
        protected readonly IMapper _mapper;

        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }

        //Shared controller code
        protected string GetAbsoluteUrlOfCaller()
        {
            var referrer = HttpContext.Current.Request.UrlReferrer;
            return referrer.AbsoluteUri;
        }
    }
}
