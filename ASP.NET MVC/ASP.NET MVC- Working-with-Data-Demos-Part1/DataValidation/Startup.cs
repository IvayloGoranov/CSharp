using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DataValidation.Startup))]
namespace DataValidation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
