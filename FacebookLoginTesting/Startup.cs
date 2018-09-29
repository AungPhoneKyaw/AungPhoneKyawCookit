using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FacebookLoginTesting.Startup))]
namespace FacebookLoginTesting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
