using System.ComponentModel.DataAnnotations;
using static CameraBazaar.Models.Constants.ValidationRegularExpressions;
using static CameraBazaar.Models.Constants.ValidationMessages;

namespace CameraBazaar.Models.BindingModels
{
    public class EditUserBm
    {
        [EmailAddress, Required]
        public string Email { get; set; }

        [Required, RegularExpression(PasswordRegex,
            ErrorMessage = PasswordValidationMessage)]
        public string Password { get; set; }

        [Required, RegularExpression(PhoneRegex, ErrorMessage = PhoneValidationMessage)]
        public string Phone { get; set; }

        [Required, RegularExpression(PasswordRegex,
           ErrorMessage = PasswordValidationMessage)]      
        public string CurrentPassword { get; set; }
    }
}
