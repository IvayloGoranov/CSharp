using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;

using Twitter.Models;

namespace Twitter.Web.InputModels
{
    public class EditUserInputModel
    {
        [StringLength(100, ErrorMessage = "The Full name must be between {1} and {2} characters long.",
            MinimumLength = 2)]
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [StringLength(100, ErrorMessage = "The {0} name must be between {1} and {2} characters long.",
            MinimumLength = 10)]
        public string Summary { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public byte[] Avatar { get; set; }

        public static EditUserInputModel FromModel(User user)
        {
            return new EditUserInputModel
            {
                FullName = user.FullName,
                Summary = user.Summary,
                Avatar = user.Avatar == null ? null : user.Avatar.Avatar,
                Email = user.Email
            };
        }

        internal User UpdateUser(User user)
        {
            user.FullName = this.FullName;
            user.Summary = this.Summary;
            user.Email = this.Email;

            if (this.Password != null)
            {
                user.PasswordHash = Crypto.HashPassword(this.Password);
            }

            return user;
        }
    }
}