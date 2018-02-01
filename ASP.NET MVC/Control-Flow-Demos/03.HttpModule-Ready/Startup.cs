using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_03.HttpModule_Ready.Startup))]
namespace _03.HttpModule_Ready
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
