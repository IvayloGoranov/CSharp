using _02.HttpHandler_Ready.Handlers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _02.HttpHandler_Ready
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Add(new Route("home/about", new SampleRouteHandler()));

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }

    internal class SampleRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new SampleHandler();
        }
    }
}
