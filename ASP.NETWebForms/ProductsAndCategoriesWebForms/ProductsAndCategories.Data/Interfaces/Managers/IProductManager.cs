using System.Linq;

namespace ProductsAndCategories.Data.Interfaces.Managers
{
    public interface IProductManager : IManager<Product>
    {
        IQueryable<GetProductsByCategoryIDResult> GetProductsByCategoryID(int categoryId);
    }
}
