using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_02.HttpHandler_Ready.Startup))]
namespace _02.HttpHandler_Ready
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
