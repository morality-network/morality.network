using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RateItHome.Startup))]
namespace RateItHome
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
