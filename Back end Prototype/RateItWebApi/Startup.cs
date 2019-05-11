using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;

[assembly: OwinStartup(typeof(RateItWebApi.Startup))]

namespace RateItWebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);
        }
    }
}
