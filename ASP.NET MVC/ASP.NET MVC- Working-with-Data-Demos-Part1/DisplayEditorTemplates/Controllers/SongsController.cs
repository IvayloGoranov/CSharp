namespace DisplayEditorTemplates.Controllers
{
    using DisplayEditorTemplates.Models;
    using System;
    using System.Web.Mvc;

    public class SongsController : Controller
    {
        public ActionResult Index()
        {
            var song = new SongModel
            {
                Title = "In The End",
                Author = "Linkin Park",
                Length = 3,
                Date = new DateTime(1999, 11, 10)
            };

            return View(song);
        }

        public ActionResult Details()
        {
            var song = new SongModel
            {
                Title = "In The End",
                Author = "Linkin Park",
                Length = 3,
                Date = new DateTime(1999, 11, 10)
            };

            return View(song);
        }
    }
}