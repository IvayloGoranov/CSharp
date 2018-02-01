namespace LinkedIn.Web.Controllers
{
    using System.Linq;
    using AutoMapper;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Data;
    using ViewModels;

    public class HomeController : BaseController
    {
        public HomeController(LinkedInData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var certificates = this.UserProfile.Certifications
                .AsQueryable()
                .Project()
                .To<CertificationViewModel>();

            return this.View(certificates);
        }

        public ActionResult About()
        {
            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}