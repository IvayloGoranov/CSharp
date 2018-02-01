using System.ComponentModel.DataAnnotations;

using BookShopSystem.Models;

namespace BookShopSystem.Server.Api.DTOs.InputModels
{
    public class CategoryInputModel
    {
        [Required]
        [MaxLength(200)]
        public string CategoryName { get; set; }

        internal Category UpdateCategory(Category categoryToEdit)
        {
            categoryToEdit.CategoryName = this.CategoryName;

            return categoryToEdit;
        }

        internal Category CreateCategory()
        {
            var newCategory = new Category
            {
                CategoryName = this.CategoryName
            };

            return newCategory;
        }
    }
}