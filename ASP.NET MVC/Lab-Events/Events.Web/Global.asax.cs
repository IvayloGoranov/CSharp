namespace Events.Web
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Data.Entity;

    using Events.Data;
    using Events.Data.Migrations;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<
                ApplicationDbContext, DbMigrationsConfig>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
