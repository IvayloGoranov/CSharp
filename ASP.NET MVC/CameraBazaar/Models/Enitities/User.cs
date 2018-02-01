using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CameraBazaar.Models.Attributes;
using static CameraBazaar.Models.Constants.ValidationMessages;
using static CameraBazaar.Models.Constants.ValidationRegularExpressions;

namespace CameraBazaar.Models.Enitities
{
    public class User
    {
        public User()
        {
            this.Cameras = new HashSet<Camera>();
        }
        public int Id { get; set; }

        [Username, Required]
        public string Username { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }

        [Required, RegularExpression(PasswordRegex,
            ErrorMessage = PasswordValidationMessage)]
        public string Password { get; set; }

        [Required, RegularExpression(PhoneRegex, ErrorMessage = PhoneValidationMessage)]
        public string Phone { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public virtual ICollection<Camera> Cameras { get; set; }
    }
}
