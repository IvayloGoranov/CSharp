using System.Data.Linq;

namespace ProductsAndCategories.Data.Interfaces
{
    public interface IProductsAndCategoriesDataContext
    {
        Table<Category> Categories { get; }

        Table<Product> Products { get; }
    }
}
