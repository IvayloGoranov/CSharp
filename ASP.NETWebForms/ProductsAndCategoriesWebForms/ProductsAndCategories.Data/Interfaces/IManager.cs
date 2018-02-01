using System.Collections.Generic;
using System.Linq;

namespace ProductsAndCategories.Data.Interfaces
{
    public interface IManager<TEntity>
    {
        TEntity Get(int id);

        IQueryable<TEntity> List();

        void Delete(int id);

        void Delete(TEntity entity);

        void Delete(IEnumerable<int> ids);

        int GetCount();

        TEntity Save(TEntity entity);
    }
}
