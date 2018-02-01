using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fruits.Web.IdentityData.Interfaces
{
    public interface IEfCoreRepository<T> where T : EfCoreBaseModel<int>
    {
        DbSet<T> Set { get; }

        Task<int> Add(T entity);

        Task<int> Delete(int id);

        Task<int> HardDelete(int id);

        Task<int> Delete(T entity);

        Task<int> HardDelete(T entity);

        Task<T> Find(int id);

        Task<T> FindByCreationDate(DateTime creationDate);

        IQueryable<T> GetAll();

        IQueryable<T> GetAllWithDeleted();

        Task<int> Update();
    }
}
