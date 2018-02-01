using System.ComponentModel.DataAnnotations;

namespace CameraBazaar.Models.BindingModels
{
    public class LoginUserBm
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
