using System.ComponentModel.DataAnnotations;
using CameraBazaar.Models.Attributes;
using static CameraBazaar.Models.Constants.ValidationMessages;
using static CameraBazaar.Models.Constants.ValidationRegularExpressions;

namespace CameraBazaar.Models.ViewModels
{
    public class RegisterUserVm
    {
        [Username, Required]
        public string Username { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }

        [Required, RegularExpression(PasswordRegex,
            ErrorMessage = PasswordValidationMessage)]
        public string Password { get; set; }

        [Required, RegularExpression(PasswordRegex,
            ErrorMessage = PasswordValidationMessage)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required, RegularExpression(PhoneRegex, ErrorMessage = PhoneValidationMessage)]
        public string Phone { get; set; }
    }
}
