using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_04.HttpModulesInAspNet.Startup))]
namespace _04.HttpModulesInAspNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
