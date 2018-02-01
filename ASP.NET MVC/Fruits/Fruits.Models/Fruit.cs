using System.ComponentModel.DataAnnotations;

using Fruits.Models.Enums;

namespace Fruits.Models
{
    public class Fruit : BaseModel<int>
    {
        [Required]
        [StringLength(20, ErrorMessage = "Fruit name should be between {1} and {2} characters long.",
           MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public Color Color { get; set; }

        [StringLength(50, ErrorMessage = "Fruit description should be between {1} and {2} characters long.",
           MinimumLength = 2)]
        public string Description { get; set; }

        [Required]
        public Importance Importance { get; set; }

        [Required]
        [Range(0.0, double.MaxValue,
            ErrorMessage = "Fruit price value should be bigger than or equal to 0.")]
        public decimal Price { get; set; }
    }
}
