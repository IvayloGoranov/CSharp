using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

using Fruits.Models;

namespace Fruits.Data.Interfaces
{
    public interface IRepository<T> where T : BaseModel<int>
    {
        IDbSet<T> Set { get; }

        IQueryable<T> GetAll();

        IQueryable<T> GetAllWithDeleted();

        Task<T> Find(int id);

        Task<T> FindByCreationDate(DateTime creationDate);

        Task<int> Add(T entity);

        Task<int> Delete(int id);

        Task<int> HardDelete(int id);

        Task<int> Delete(T entity);

        Task<int> HardDelete(T entity);

        Task<int> Update(T entity);
    }
}
