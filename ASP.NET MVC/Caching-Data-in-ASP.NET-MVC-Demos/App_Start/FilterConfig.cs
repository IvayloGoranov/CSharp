using System.Web;
using System.Web.Mvc;

namespace Caching_Data_MVC_Demos
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
