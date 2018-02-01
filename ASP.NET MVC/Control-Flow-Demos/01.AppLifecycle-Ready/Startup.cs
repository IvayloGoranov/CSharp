using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_01.AppLifecycle_Ready.Startup))]
namespace _01.AppLifecycle_Ready
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
