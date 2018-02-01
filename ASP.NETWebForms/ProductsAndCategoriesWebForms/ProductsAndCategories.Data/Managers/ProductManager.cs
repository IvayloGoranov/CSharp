using System.Linq;

using ProductsAndCategories.Data.Interfaces.Managers;

namespace ProductsAndCategories.Data.Managers
{
    public class ProductManager : ManagerBase<Product>, IProductManager
    {
        public IQueryable<GetProductsByCategoryIDResult> GetProductsByCategoryID(int categoryId)
        {
            var productsForCategory = this.context.GetProductsByCategoryID(categoryId).AsQueryable();

            return productsForCategory;
        }
    }
}
