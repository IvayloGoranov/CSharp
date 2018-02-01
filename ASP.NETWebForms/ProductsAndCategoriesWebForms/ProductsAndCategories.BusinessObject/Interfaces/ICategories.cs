using System.Collections.Generic;

using ProductsAndCategories.Ordering.Data;

namespace ProductsAndCategories.BusinessObject.Interfaces
{
    public interface ICategories
    {
        IEnumerable<CategoryItem> GetFilteredCategories(
            int itemsCount = GlobalConstants.GlobalConstants.DefaultItemsCount,
            string nameFilter = null);

        CategoryItem Get(int id);

        CategoryItem Save(CategoryItem categoryItem);

        void Delete(int id);

        int GetCount();

        int GetMaxOrderNo();
    }
}
