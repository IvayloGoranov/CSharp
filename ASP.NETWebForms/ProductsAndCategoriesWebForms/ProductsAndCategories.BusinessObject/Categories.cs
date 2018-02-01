using System.Collections.Generic;
using System.Linq;
using System;

using ProductsAndCategories.Data.Interfaces.Managers;
using ProductsAndCategories.Data.Managers;
using ProductsAndCategories.Ordering.Data;
using ProductsAndCategories.BusinessObject.Interfaces;
using ProductsAndCategories.Data;
using ProductsAndCategories.Data.Enums;

namespace ProductsAndCategories.BusinessObject
{
    public class Categories : ICategories
    {
        private ICategoryManager categoryManager;

        public Categories(ICategoryManager categoryManager)
        {
            this.categoryManager = categoryManager;
        }

        public Categories()
            : this(new CategoryManager())
        {
        }

        public virtual IEnumerable<CategoryItem> GetFilteredCategories(
            int itemsCount = GlobalConstants.GlobalConstants.DefaultItemsCount, 
            string nameFilter = null)
        {
            var categoriesFiltered = this.categoryManager.GetFilteredCategories(itemsCount, nameFilter)
                                                         .ToList()
                                                         .Select(x => new CategoryItem
                                                         {
                                                             Id = x.ID,
                                                             Name = x.Name,
                                                             Color = (Color)x.Color,
                                                             ProductsTotalPrice = x.ProductsTotalPrice.HasValue ? (decimal)x.ProductsTotalPrice : 0m,
                                                             OrderNo = x.OrderNo
                                                         });

            return categoriesFiltered;                                     
        }

        public virtual CategoryItem Get(int id)
        {
            var category = this.categoryManager.List()
                                               .Where(x => x.ID == id)
                                               .Select(x => new CategoryItem
                                               {
                                                    Id = x.ID,
                                                    Name = x.Name,
                                                    Color = (Color)x.Color,
                                                    Description = x.Description,
                                                    OrderNo = x.OrderNo
                                               })
                                                .FirstOrDefault();

            if (category == null)
            {
                throw new KeyNotFoundException(string.Format("No category with id {0} found in the database", id));
            }

            return category;
        }

        public virtual CategoryItem Save(CategoryItem categoryItem)
        {
            if (categoryItem == null)
            {
                throw new ArgumentException("CategoryItem cannot be null");
            }

            if (string.IsNullOrEmpty(categoryItem.Name))
            {
                throw new ArgumentException("Category name is required");
            }

            Category category = null;
            if (categoryItem.Id == 0)
            {
                category = categoryItem.CreateCategory();
            }
            else
            {
                category = this.categoryManager.Get(categoryItem.Id);
                categoryItem.UpdateCategory(category);
            }

            var categoryInDB = this.categoryManager.Save(category);
            var categoryItemToReturn = CategoryItem.FromModel(categoryInDB);

            return categoryItemToReturn;
        }

        public virtual void Delete(int id)
        {
            this.categoryManager.Delete(id);
        }

        public virtual int GetCount()
        {
            return this.categoryManager.GetCount();
        }

        public virtual int GetMaxOrderNo()
        {
            return this.categoryManager.List()
                                       .Max(x => x.OrderNo);
        }
    }
}
