using System.ComponentModel.DataAnnotations;

using Fruits.Models.Enums;
using Fruits.Models;

namespace Fruits.Web.InputModels.Fruits
{
    public class FruitInputModel
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

        public static FruitInputModel FromModel(Fruit fruit)
        {
            return new FruitInputModel
            {
                Name = fruit.Name,
                Color = fruit.Color,
                Description = fruit.Description,
                Importance = fruit.Importance,
                Price = fruit.Price
            };
        }

        internal Fruit CreateFruit()
        {
            var newFruit = new Fruit
            {
                Name = this.Name,
                Color = this.Color,
                Description = this.Description,
                Importance = this.Importance,
                Price = this.Price
            };

            return newFruit;
        }

        internal void UpdateFruit(Fruit fruit)
        {
            fruit.Name = this.Name;
            fruit.Color = this.Color;
            fruit.Description = this.Description;
            fruit.Importance = this.Importance;
            fruit.Price = this.Price;
        }
    }
}
