using System.Web.Mvc;
using Helpers.Models;

namespace Helpers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var people = new Person[]
            {
                new Person() {Name = "John Doe", Age = 40, Email = "john@office.com", IsSubscribed = true},
                new Person() {Name = "John Doe Jr.", Email = "john@office.com"},
                new Person() {Name = "Mickey Mouse", Age = 20, IsSubscribed = true},
            };

            return View(people);
        }

        public ActionResult Images()
        {
            return this.View();
        }

        public ActionResult Videos()
        {
            return this.View();
        }

        public ActionResult Table()
        {
            Human[] humans = new Human[]
            {
              new Human() { Id = 1, Name = "John Doe", Age = 40}  ,
              new Human() {Id = 2, Name = "John Doe Jr", Age = 22}
            };

            return this.View(humans);
        }
    }
}