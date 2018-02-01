using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OnlineShop.Server.Api.Startup))]

namespace OnlineShop.Server.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
