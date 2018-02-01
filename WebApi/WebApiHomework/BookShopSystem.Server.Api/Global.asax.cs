using System.Web;
using System.Web.Http;

namespace BookShopSystem.Server.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutofacConfig.RegisterAutofac();
            
        }
    }
}
