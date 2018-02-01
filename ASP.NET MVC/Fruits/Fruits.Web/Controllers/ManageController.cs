using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Fruits.Web.IdentityData;
using Fruits.Web.Enums;
using Fruits.Web.InputModels.Manage;
using Fruits.Web.ViewModels.Manage;

namespace Fruits.Web.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ILogger logger;

        public ManageController(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        ILoggerFactory loggerFactory)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = loggerFactory.CreateLogger<ManageController>();
        }

        //
        // GET: /Manage/Index
        [HttpGet]
        public async Task<IActionResult> Index(ManageMessageId? message = null)
        {
            this.ViewData["StatusMessage"] =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : "";

            var user = await this.GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            var model = new IndexViewModel
            {
                HasPassword = await userManager.HasPasswordAsync(user),
                PhoneNumber = await userManager.GetPhoneNumberAsync(user),
                TwoFactor = await userManager.GetTwoFactorEnabledAsync(user),
                Logins = await userManager.GetLoginsAsync(user),
                BrowserRemembered = await signInManager.IsTwoFactorClientRememberedAsync(user)
            };
            return this.View(model);
        }

        // GET: /Manage/ChangePassword
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return this.View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            var user = await this.GetCurrentUserAsync();
            if (user != null)
            {
                var result = await this.userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    await this.signInManager.SignInAsync(user, isPersistent: false);
                    this.logger.LogInformation(3, "User changed their password successfully.");
                    return this.RedirectToAction(nameof(Index), new { Message = ManageMessageId.ChangePasswordSuccess });
                }

                this.AddErrors(result);

                return this.View(model);
            }

            return this.RedirectToAction(nameof(Index), new { Message = ManageMessageId.Error });
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
    }
}
