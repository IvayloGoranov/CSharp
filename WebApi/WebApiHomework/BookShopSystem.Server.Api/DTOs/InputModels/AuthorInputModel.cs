using System.ComponentModel.DataAnnotations;

namespace BookShopSystem.Server.Api.DTOs.InputModels
{
    public class AuthorInputModel
    {
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
    }
}