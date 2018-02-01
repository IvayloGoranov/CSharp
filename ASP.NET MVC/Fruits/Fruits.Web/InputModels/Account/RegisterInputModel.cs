using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

using Fruits.Web.ViewModels.Fruits;

namespace Fruits.Web.InputModels.Account
{
    public class RegisterInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public IEnumerable<SubscriptionViewModel> Subscriptions { get; set; }
    }
}
