using System;
using System.Linq;
using System.Linq.Expressions;

using BookShopSystem.Models;

namespace BookShopSystem.Server.Api.DTOs.ViewModels
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
                    CategoryName = x.CategoryName,
                };
            }
        }

        public int Id { get; set; }

        public string CategoryName { get; set; }
    }
}