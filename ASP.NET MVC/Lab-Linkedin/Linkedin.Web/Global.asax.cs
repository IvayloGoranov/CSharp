using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LinkedIn.Web
{
    using System.Collections.Generic;
    using System.Reflection;

    using App_Start;
    using LinkedIn.Common.Mappings;
    using LinkedIn.Web.ModelBinders;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ViewEnginesConfig.RegisterViewEngines(ViewEngines.Engines);

            var autoMapper = new AutoMapperConfig(new[] {Assembly.GetExecutingAssembly()});
            autoMapper.Execute();

            ModelBinderProviders.BinderProviders.Add(new EntityModelBinderProvider());
        }
    }
}
