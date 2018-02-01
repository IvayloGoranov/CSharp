using SimpleMVC.App.MVC.Controllers;
using SimpleMVC.App.MVC.Interfaces;

namespace SimpleMVC.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
