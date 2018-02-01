using DataValidation.Models;

namespace DataValidation.Controllers
{
    using System.Web.Mvc;

    public class StudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Add(Student model)
        {
            if (this.ModelState != null && this.ModelState.IsValid)
            {
                this.db.Students.Add(model);
                this.db.SaveChanges();

                this.TempData["FullName"] = model.FullName;
                return this.RedirectToAction("SuccessAdd");
            }

            return this.View(model);
        }

        public ActionResult SuccessAdd()
        {
            return this.View();
        }
    }
}