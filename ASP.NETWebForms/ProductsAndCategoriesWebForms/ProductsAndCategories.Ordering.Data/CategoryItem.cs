
using ProductsAndCategories.Data;
using ProductsAndCategories.Data.Enums;

namespace ProductsAndCategories.Ordering.Data
{
    public class CategoryItem
    {
        public int Id { get; set; }

        public int OrderNo { get; set; }

        public string Name { get; set; }

        public Color Color { get; set; }

        public decimal ProductsTotalPrice { get; set; }

        public string Description { get; set; }

        public static CategoryItem FromModel(Category category)
        {
            return new CategoryItem
            {
                Id = category.ID,
                OrderNo = category.OrderNo,
                Name = category.Name,
                Color = (Color)category.Color,
                Description = category.Description
            };
        }

        public Category CreateCategory()
        {
            return new Category
            {
                Name = this.Name,
                Color = (byte)this.Color,
                Description = this.Description
            };
        }

        public void UpdateCategory(Category category)
        {
            category.Name = this.Name;
            category.OrderNo = this.OrderNo;
            category.Color = (byte)this.Color;
            category.Description = this.Description;
        }
    }
}
