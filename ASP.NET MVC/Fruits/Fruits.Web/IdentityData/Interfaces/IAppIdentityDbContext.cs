using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace Fruits.Web.IdentityData.Interfaces
{
    public interface IAppIdentityDbContext
    {
        DbSet<Subscription> Subscriptions { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
