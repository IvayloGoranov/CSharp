namespace LinkedIn.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using AutoMapper;

    using LinkedIn.Data;
    using LinkedIn.Data.Models;
    using LinkedIn.Models;
    using LinkedIn.Web.Infrastructure.ActionFilters;
    using LinkedIn.Web.Infrastructure.CacheService;
    using LinkedIn.Web.InputModels;
    using LinkedIn.Web.ViewModels;

    public class GroupsController : BaseController
    {
        private ICacheService cacheService;

        public GroupsController(LinkedInData data, ICacheService cacheService)
            : base(data)
        {
            this.cacheService = cacheService;
        }

        [PopulateGroupNames]
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult GetById(Group group)
        //{
        //    var groupViewModel = Mapper.Map<GroupViewModel>(group);
        //    return this.View(groupViewModel);
        //}

        public ActionResult GetById(Group group)
        {
            return this.AutoMapperObjectView<Group, GroupViewModel>(this.View(group));
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(GroupInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var group = new Group()
                {
                    Id = model.Id,
                    Title = model.Title,
                    OwnerId = model.OwnerId,
                    Type = model.Type,
                    Website = model.Website
                };

                this.Data.Groups.Add(group);
                this.Data.SaveChanges();

                return this.RedirectToAction(x => x.SuccessCreate());
            }

            return this.View(model);
        }

        public ActionResult SuccessCreate()
        {
            return null;
        }
    }
}