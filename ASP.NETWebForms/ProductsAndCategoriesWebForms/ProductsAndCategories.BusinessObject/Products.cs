using System.Collections.Generic;
using System.Linq;
using System;

using ProductsAndCategories.Data.Interfaces.Managers;
using ProductsAndCategories.Data.Managers;
using ProductsAndCategories.Ordering.Data;
using ProductsAndCategories.BusinessObject.Interfaces;
using ProductsAndCategories.Data;

namespace ProductsAndCategories.BusinessObject
{
    public class Products : IProducts
    {
        private IProductManager productManager;

        public Products(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        public Products()
            : this(new ProductManager())
        {
        }

        public virtual IEnumerable<ProductItem> GetProductsByCategoryID(int categoryId)
        {
            if (categoryId < 0)
            {
                throw new KeyNotFoundException(string.Format("No category with id {0} found in the database", categoryId));
            }

            var productsForCategory = this.productManager.GetProductsByCategoryID(categoryId)
                                                         .ToList()
                                                         .Select(x => new ProductItem
                                                         {
                                                             Id = x.ID,
                                                             Name = x.Name,
                                                             Price = x.Price,
                                                             CreatedDate = x.CreatedDate.ToString("d MMM yyyy"),
                                                             CategoryId = categoryId
                                                         });


            return productsForCategory;
        }

        public virtual ProductItem Get(int id)
        {
            var product = this.productManager.List()
                                               .Where(x => x.ID == id)
                                               .Select(x => new ProductItem
                                               {
                                                   Id = x.ID,
                                                   Name = x.Name,
                                                   Price = x.Price,
                                                   CategoryId = x.CategoryID
                                               })
                                               .FirstOrDefault();

            if (product == null)
            {
                throw new KeyNotFoundException(string.Format("No product with id {0} found in the database", id));
            }

            return product;
        }

        public virtual ProductItem Save(ProductItem productItem)
        {
            if (productItem == null)
            {
                throw new ArgumentException("ProductItem cannot be null");
            }

            if (string.IsNullOrEmpty(productItem.Name))
            {
                throw new ArgumentException("Product name is required");
            }

            Product product = null;
            if (productItem.Id == 0)
            {
                product = productItem.CreateProduct();
            }
            else
            {
                product = this.productManager.Get(productItem.Id);
                productItem.UpdateProduct(product);
            }

            var productInDB = this.productManager.Save(product);
            var productItemToReturn = ProductItem.FromModel(productInDB);

            return productItemToReturn;
        }

        public virtual void Delete(int id)
        {
            this.productManager.Delete(id);
        }
    }
}
