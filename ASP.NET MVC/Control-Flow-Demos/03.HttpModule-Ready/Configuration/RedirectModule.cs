using System;
using System.Web;
using System.Web.Configuration;

namespace _03.HttpModule_Ready.Configuration
{
    public class RedirectModule : IHttpModule
    {
        private HttpApplication context;

        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            this.context = context;
            context.PostMapRequestHandler += RedirectUrls;
        }

        public void RedirectUrls(object src, EventArgs args)
        {
            RedirectSection section = (RedirectSection)WebConfigurationManager.GetWebApplicationSection("redirects");




            foreach (Redirect redirect in section.Redirects)
            {
                if (redirect.Old == this.context.Request.RequestContext.HttpContext.Request.RawUrl)
                {
                    this.context.Response.Redirect(redirect.New);
                }
            }

        }
    }
}