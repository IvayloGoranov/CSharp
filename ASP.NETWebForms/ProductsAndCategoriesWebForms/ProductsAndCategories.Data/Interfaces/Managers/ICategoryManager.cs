using System.Linq;

namespace ProductsAndCategories.Data.Interfaces.Managers
{
    public interface ICategoryManager : IManager<Category>
    {
        IQueryable<GetFilteredCategoriesResult> GetFilteredCategories(int itemsCount, string nameFilter = null);
    }
}
