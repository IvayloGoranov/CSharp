namespace Caching_Data_MVC_Demos.Controllers
{
    using System;
    using System.IO;
    using System.Web.Caching;
    using System.Web.Mvc;

    public class FilesController : Controller
    {
        public ActionResult Index()
        {
            if (this.HttpContext.Cache["files"] == null)
            {
                var folder = Server.MapPath("~/Images");
                var files = Directory.EnumerateFiles(folder);
                this.HttpContext.Cache.Insert("files", files, new CacheDependency(folder));
                this.HttpContext.Cache.Insert("filesLastChanged", DateTime.Now, new CacheDependency(folder));
            }
            this.ViewBag.Files = this.HttpContext.Cache["files"];
            this.ViewBag.FilesLastChanged = this.HttpContext.Cache["filesLastChanged"];
            return View();
        }
    }
}
