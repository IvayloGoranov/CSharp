using System.ComponentModel.DataAnnotations;

namespace CarsShop.Models.Entities
{
    public class Car
    {
        public int Id { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
