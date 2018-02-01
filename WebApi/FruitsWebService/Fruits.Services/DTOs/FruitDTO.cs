using System;
using System.Linq.Expressions;

    using Fruits.Models;

namespace Fruits.Services.DTOs
{
    public class FruitDTO
    {
        public static Expression<Func<Fruit, FruitDTO>> MapToDTO
        {
            get
            {
                return x => new FruitDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
