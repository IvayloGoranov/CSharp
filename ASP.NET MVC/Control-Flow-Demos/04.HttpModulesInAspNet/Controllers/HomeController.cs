using System.Web;
using System.Web.Mvc;

namespace _04.HttpModulesInAspNet.Controllers
{
    public class HomeController : Controller
    {
        public void Index()
        {
            HttpApplication httpApps = HttpContext.ApplicationInstance;
            HttpModuleCollection httpModuleCollections = httpApps.Modules;
            Response.Write("Total Number Active HttpModule: " + httpModuleCollections.Count.ToString() + "</br>");
            Response.Write("<b>List of Active Modules</b>" + "</br>");
            foreach (string activeModule in httpModuleCollections.AllKeys)
            {
                Response.Write(activeModule + "</br>");
            }
            
        }
    }
}