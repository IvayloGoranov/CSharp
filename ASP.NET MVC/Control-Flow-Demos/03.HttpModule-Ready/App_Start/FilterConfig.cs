using System.Web;
using System.Web.Mvc;

namespace _03.HttpModule_Ready
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
