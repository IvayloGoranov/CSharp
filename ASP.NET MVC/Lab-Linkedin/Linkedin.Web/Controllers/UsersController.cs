namespace LinkedIn.Web.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;
    using Data.Models;

    using LinkedIn.Models;

    using ViewModels;

    [Authorize]
    public class UsersController : BaseController
    {
        public UsersController(LinkedInData data) : base(data)
        {
        }

        public ActionResult Index(string username)
        {
            var user = this.Data.Users
                .All()
                .Include(x => x.ContactInfo.Twitter)
                .Include(x => x.Certifications)
                .Include(x => x.Skills)
                .Include("Skills.Skill")
                .Include("Skills.Skill.User")
                .Where(x => x.UserName == username)
                .Project()
                .To<UserViewModel>()
                .FirstOrDefault();
            
            if (user == null)
            {
                return this.HttpNotFound("User does not exist!");
            }

            return this.View(user);
        }

        public ActionResult Test()
        {

            var users = this.Data.Users
                .All()
                .Project()
                .To<UserViewModel>()
                .ToList();
            
            var viewModel = Mapper.Map<UserViewModel>(this.UserProfile);

            return null;
        }

        public ActionResult TestMany()
        {
            Mapper.CreateMap<User, UserViewModel>();

            var users = this.Data.Users
                .All()
                .Project()
                .To<UserViewModel>()
                .ToList();

            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EndorseUserForSkill(int id)
        {
            var userSkillEndorcement = this.Data.Endorcements.All().Where(x => x.UserSkillId == id);

            var hasExistingEndorcement = userSkillEndorcement.Any(x => x.UserId == this.UserProfile.Id);
            if (!hasExistingEndorcement)
            {
                this.Data.Endorcements.Add(new Endorcement
                {
                    UserId = this.UserProfile.Id,
                    UserSkillId = id
                });

                this.Data.SaveChanges();
            }

            var endorcementsCount = userSkillEndorcement.Count();
            var endorcers = userSkillEndorcement.Select(x => x.User.UserName).ToList();

            return this.Content(string.Format("{0} ({1})", endorcementsCount, string.Join(",", endorcers)));
        }
    }
}