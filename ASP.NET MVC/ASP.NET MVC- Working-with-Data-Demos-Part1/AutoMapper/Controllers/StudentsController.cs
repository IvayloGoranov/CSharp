using System.Linq;
using System.Web.Mvc;

using AutoMapper.Models;
using DataValidation.Models;
using AutoMapper.ViewModels;

namespace AutoMapper.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var student = this.db.Students.FirstOrDefault();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student, StudentViewModel>();
            });

            IMapper mapper = config.CreateMapper();
            var source = new Student();
            var dest = mapper.Map<Student, StudentViewModel>(source);

            return this.View(dest);
        }
    }
}