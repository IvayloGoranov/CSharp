using System.Linq;

using ProductsAndCategories.Data.Interfaces.Managers;

namespace ProductsAndCategories.Data.Managers
{
    public class CategoryManager : ManagerBase<Category>, ICategoryManager
    {
        public const int DefaultItemsCount = 5;

        public IQueryable<GetFilteredCategoriesResult> GetFilteredCategories(
            int itemsCount = GlobalConstants.GlobalConstants.DefaultItemsCount, 
            string nameFilter = null)
        {
            var categoriesFiltered = this.context.GetFilteredCategories(itemsCount, nameFilter).AsQueryable();

            return categoriesFiltered;
        }

        protected override Category OnInsert(Category entity)
        {
            var entityInDb = base.OnInsert(entity);

            entityInDb.OrderNo = entityInDb.ID;

            return base.OnUpdate(entityInDb);
        }
    }
}
