namespace Caching_Data_MVC_Demos.Controllers
{
    using System;
    using System.IO;
    using System.Web.Caching;
    using System.Web.Mvc;
    using System.Web.UI;

    public class TimeController : Controller
    {
        [OutputCache(Duration = 10, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 3600, VaryByParam = "id")]
        public ActionResult VaryByParam()
        {
            return View();
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server)]
        public ActionResult ServerCache()
        {
            return View();
        }

        public ActionResult ClearServerCache()
        {
            var urlToRemove = Url.Action("ServerCache", "Time");
            Response.RemoveOutputCacheItem(urlToRemove);
            return RedirectToAction("ServerCache");
        }

        [OutputCache(Duration = 3600, VaryByParam = "none",
            Location = OutputCacheLocation.Client)]
        public ActionResult ClientCache()
        {
            return View();
        }

        [OutputCache(CacheProfile = "Profile15Sec")]
        public ActionResult Profile15Sec()
        {
            return View();
        }

        public ActionResult ViewWithPartial()
        {
            return View();
        }

        [OutputCache(Duration = 10, VaryByParam = "none")]
        [ChildActionOnly]
        public PartialViewResult PartialView()
        {
            return PartialView("_PartialView");
        }

        public ActionResult DataCache()
        {
            if (this.HttpContext.Cache["time"] == null)
            {
                this.HttpContext.Cache["time"] = DateTime.Now;
            }
            
            this.ViewBag.Time = this.HttpContext.Cache["time"];
            return View();
        }

        public ActionResult InvalidateCache()
        {
            this.HttpContext.Cache.Remove("time");
            return this.RedirectToAction("DataCache");
        }
    }
}