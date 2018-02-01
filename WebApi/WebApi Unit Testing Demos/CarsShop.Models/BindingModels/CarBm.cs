using System.ComponentModel.DataAnnotations;

namespace CarsShop.Models.BindingModels
{
    public class CarBm
    {
        [MinLength(3)]
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
