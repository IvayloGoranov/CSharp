using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

using Fruits.Web.IdentityData;
using Fruits.Web.IdentityData.Interfaces;
using Fruits.Web.InputModels.Account;
using Fruits.Web.ViewModels.Fruits;
using System.Globalization;
using Fruits.Web.IdentityData.DbContextExtensions;

namespace Fruits.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ILogger logger;

        private IEfCoreRepository<Subscription> subscriptionsRepo;
        private IUsersRepository usersRepo;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ILoggerFactory loggerFactory,
            IEfCoreRepository<Subscription> subscriptionsRepo, IUsersRepository usersRepo)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = loggerFactory.CreateLogger<AccountController>();
            this.subscriptionsRepo = subscriptionsRepo;
            this.usersRepo = usersRepo;
        }

        //
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            this.ViewData["ReturnUrl"] = returnUrl;

            return this.View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInputModel model, string returnUrl = null)
        {
            this.ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await this.signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    logger.LogInformation(1, "User logged in.");
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return this.View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
        }

        //
        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            this.ViewData["ReturnUrl"] = returnUrl;

            var subscriptions = this.subscriptionsRepo.GetAll()
                                                      .Select(SubscriptionViewModel.MapToDTO)
                                                      .ToList();
            var model = new RegisterInputModel { Subscriptions = subscriptions };

            var countries = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                                       .Select(x => new RegionInfo(x.LCID).EnglishName)
                                       .Distinct()
                                       .OrderBy(x => x);
            this.ViewBag.Countries = countries;

            return this.View(model);
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterInputModel model, string returnUrl = null)
        {
            this.ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Email, Email = model.Email, Country = model.Country };
                var createUserResult = await this.userManager.CreateAsync(user, model.Password);
                if (createUserResult.Succeeded)
                {
                    var addRolesResult = await this.userManager.AddToRoleAsync(user, Roles.Client);
                    if (addRolesResult.Succeeded)
                    {
                        foreach (var subscription in model.Subscriptions)
                        {
                            if (subscription.Checked)
                            {
                                var newUserSubscription = new UserSubscription { SubscriptionId = subscription.Id, UserId = user.Id };
                                var userFromDb = await this.usersRepo.Find(user.Id);
                                userFromDb.Subscriptions.Add(newUserSubscription);
                                await this.usersRepo.Update();
                            }
                        }

                        await this.signInManager.SignInAsync(user, isPersistent: false);
                        this.logger.LogInformation(3, "User created a new account with password.");

                        return this.RedirectToLocal(returnUrl);
                    }

                    this.AddErrors(addRolesResult);
                }

                this.AddErrors(createUserResult);
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await this.signInManager.SignOutAsync();
            this.logger.LogInformation(4, "User logged out.");

            return this.RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private Task<User> GetCurrentUserAsync()
        {
            return this.userManager.GetUserAsync(HttpContext.User);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (this.Url.IsLocalUrl(returnUrl))
            {
                return this.Redirect(returnUrl);
            }
            else
            {
                return this.RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
