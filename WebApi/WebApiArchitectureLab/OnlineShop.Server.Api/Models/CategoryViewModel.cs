using System;
using System.Linq.Expressions;

using OnlineShop.Models;

namespace OnlineShop.Server.Api.Models
{
    public class CategoryViewModel
    {
        public static Expression<Func<Category, CategoryViewModel>> MapToViewModel
        {
            get
            {
                return x => new CategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}