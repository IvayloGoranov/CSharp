using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

using Fruits.Models;

namespace Fruits.Data.Interfaces
{
    public interface IFruitsContext
    {
        IDbSet<Fruit> Fruits { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
