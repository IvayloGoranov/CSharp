using System;

using ProductsAndCategories.Data;

namespace ProductsAndCategories.Ordering.Data
{
    public class ProductItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string CreatedDate { get; set; }

        public int CategoryId { get; set; }

        public static ProductItem FromModel(Product product)
        {
            return new ProductItem
            {
                Id = product.ID,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryID,
                CreatedDate = product.CreatedDate.ToString("d MMM yyyy")
            };
        }

        public Product CreateProduct()
        {
            return new Product
            {
                ID = this.Id,
                Name = this.Name,
                Price = this.Price,
                CategoryID = this.CategoryId
            };
        }

        public void UpdateProduct(Product product)
        {
            product.Name = this.Name;
            product.Price = this.Price;
        }
    }
}
