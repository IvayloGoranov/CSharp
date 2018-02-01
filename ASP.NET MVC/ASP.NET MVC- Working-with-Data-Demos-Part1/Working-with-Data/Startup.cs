using Microsoft.Owin;
using Owin;
using Scaffolding;

[assembly: OwinStartup(typeof(Startup))]
namespace Scaffolding
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
