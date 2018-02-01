using System.ComponentModel.DataAnnotations;
using CameraBazaar.Models.Attributes;
using static CameraBazaar.Models.Constants.ValidationMessages;
using static CameraBazaar.Models.Constants.ValidationRegularExpressions;

namespace CameraBazaar.Models.BindingModels
{
    public class RegisterUserBm
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
        public string ConfirmPassword { get; set; }

        [Required, RegularExpression(PhoneRegex, ErrorMessage = PhoneValidationMessage)]
        public string Phone { get; set; }
    }
}
