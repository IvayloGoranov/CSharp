using System;
using System.Linq;

namespace Twitter.Data.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetAllWithDeleted();

        T Find(object id);

        T FindByCreationDate(DateTime creationDate);

        void Add(T entity);

        void Delete(T entity);

        void HardDelete(T entity);

        void Update(T entity);
    }
}
