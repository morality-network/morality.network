using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace RateItWebApi
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class MoralityAuthenticationFilter : AuthorizationFilterAttribute
    {
        bool Active = true;

        public MoralityAuthenticationFilter()
        { }

        public MoralityAuthenticationFilter(bool active)
        {
            Active = active;
        }

        public override Task OnAuthorizationAsync(HttpActionContext actionContext, System.Threading.CancellationToken cancellationToken)
        {

            var principal = actionContext.RequestContext.Principal as ClaimsPrincipal;
            var claims = principal.Claims.ToList();
            //var userAllowedTime = principal.FindFirst("userAllowedTime").Value;

            if (!principal.Identity.IsAuthenticated)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Failed to authenticate request");
                return Task.FromResult<object>(null);
            }

            /*if (currentTime != userAllowedTime)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Not allowed to access...bla bla");
                return Task.FromResult<object>(null);
            }*/

            return Task.FromResult<object>(null);
        }
    }
}