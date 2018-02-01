using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LinkedIn.Web.Startup))]
namespace LinkedIn.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
