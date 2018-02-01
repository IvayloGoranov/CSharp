using System.Web;
using System.Web.Mvc;
using CameraBazaar.Models.BindingModels;
using CameraBazaar.Models.Enitities;
using CameraBazaar.Models.ViewModels;
using CameraBazaar.Services;
using CameraBazaar.Web.Security;

namespace CameraBazaar.Web.Controllers
{
    [RoutePrefix("users")]
    public class UsersController : Controller
    {
        private UsersService service;

        public UsersController()
        {
            this.service = new UsersService();
        }

        [HttpGet]
        [Route("register")]
        public ActionResult Register()
        {
            return this.View(new RegisterUserVm());
        }

        [HttpPost]
        [Route("register")]
        public ActionResult Register(RegisterUserBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.RegisterUser(bind);
                return this.RedirectToAction("Login");
            }

            return this.View(new RegisterUserVm());
        }

        [HttpGet]
        [Route("login")]
        public ActionResult Login()
        {
            return this.View(new LoginUserVm());
        }


        [HttpPost]
        [Route("login")]
        public ActionResult Login(LoginUserBm bind)
        {
            if (this.ModelState.IsValid && this.service.UserExists(bind))
            {
                this.service.LoginUser(bind, this.Session.SessionID);
                this.Response.Cookies.Add(new HttpCookie("sessionId", this.Session.SessionID));
                return this.RedirectToAction("Profile");
            }

            return this.View(new LoginUserVm());
        }

        [HttpPost]
        [Route("logout")]
        public ActionResult Logout()
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            if (AuthenticationManager.IsAuthenticated(sessionId))
            {
                AuthenticationManager.Logout(sessionId);
            }

            return this.RedirectToAction("Login", "Users");
        }

        [HttpGet]
        [Route("profile/{username?}")]
        public ActionResult Profile(string username)
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            if (!AuthenticationManager.IsAuthenticated(sessionId))
            {
                return this.RedirectToAction("Login", "Users");
            }

            User user = AuthenticationManager.GetAuthenticatedUser(sessionId);
            if (string.IsNullOrEmpty(username))
            {
                ProfilePageVm loggedUserVm = this.service.GetProfilePage(user.Username, user.Username);
                if (loggedUserVm == null)
                {
                    return new HttpNotFoundResult();
                }

                return this.View("MyProfile", loggedUserVm);
            }

            ProfilePageVm vm = this.service.GetProfilePage(username, user.Username);
            return this.View(vm);
        }

        [HttpGet]
        [Route("editProfile")]
        public ActionResult EditProfile()
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            if (!AuthenticationManager.IsAuthenticated(sessionId))
            {
                return this.RedirectToAction("Login", "Users");
            }

            User user = AuthenticationManager.GetAuthenticatedUser(sessionId);
            EditUserVm vm = this.service.GetEditUserVm(user);
            return this.View(vm);
        }

        [HttpPost]
        [Route("editProfile")]
        public ActionResult EditProfile(EditUserBm bind)
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            if (!AuthenticationManager.IsAuthenticated(sessionId))
            {
                return this.RedirectToAction("Login", "Users");
            }

            User user = AuthenticationManager.GetAuthenticatedUser(sessionId);
            if (this.ModelState.IsValid && bind.CurrentPassword == user.Password)
            {
                this.service.EditUser(bind, user);
                return this.RedirectToAction("Profile");
            }

            EditUserVm vm = this.service.GetEditUserVm(user);
            return this.View(vm);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult LastLogin()
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            User user = AuthenticationManager.GetAuthenticatedUser(sessionId);
            return this.PartialView(user.LastLoginTime);
        }
    }
}

