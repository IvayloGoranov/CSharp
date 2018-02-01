namespace LinkedIn.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserLanguage
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
