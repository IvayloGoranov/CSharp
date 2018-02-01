using System.Web;
using System.Web.Mvc;

namespace _04.HttpModulesInAspNet
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
