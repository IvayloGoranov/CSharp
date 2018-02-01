using System.Web.Mvc;
using CarDealerApp.Filters;

namespace CarDealerApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new TimerAttribute());
        }
    }
}
