using System.ComponentModel.DataAnnotations;
using static CameraBazaar.Models.Constants.ValidationMessages;
using static CameraBazaar.Models.Constants.ValidationRegularExpressions;

namespace CameraBazaar.Models.ViewModels
{
    public class EditUserVm
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
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }
    }
}
