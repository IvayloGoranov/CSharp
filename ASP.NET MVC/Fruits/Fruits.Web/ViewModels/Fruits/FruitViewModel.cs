using System;
using System.Linq.Expressions;

using Fruits.Models;

namespace Fruits.Web.ViewModels.Fruits
{
    public class FruitViewModel
    {
        public static Expression<Func<Fruit, FruitViewModel>> MapToDTO
        {
            get
            {
                return x => new FruitViewModel
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
