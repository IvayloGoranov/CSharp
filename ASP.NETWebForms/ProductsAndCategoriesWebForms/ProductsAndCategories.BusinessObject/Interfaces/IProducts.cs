using System.Collections.Generic;

using ProductsAndCategories.Ordering.Data;

namespace ProductsAndCategories.BusinessObject.Interfaces
{
    public interface IProducts
    {
        IEnumerable<ProductItem> GetProductsByCategoryID(int categoryId);

        ProductItem Save(ProductItem productItem);

        void Delete(int id);

        ProductItem Get(int id);
    }
}
