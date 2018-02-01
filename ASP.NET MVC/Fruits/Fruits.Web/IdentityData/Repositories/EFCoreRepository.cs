using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

using Fruits.Web.IdentityData.Interfaces;

namespace Fruits.Web.IdentityData.Repositories
{
    public class EFCoreRepository<T> : IEfCoreRepository<T> where T : EfCoreBaseModel<int>
    {
        private IAppIdentityDbContext context;
        private DbSet<T> dbSet;

        public EFCoreRepository(IAppIdentityDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public DbSet<T> Set
        {
            get
            {
                return this.dbSet;
            }
        }

        public virtual async Task<int> Add(T entity)
        {
            this.Set.Add(entity);

            return await this.context.SaveChangesAsync(default(CancellationToken));
        }

        public virtual async Task<int> Delete(int id)
        {
            var entityToDelete = await this.Find(id);

            return await this.Delete(entityToDelete);
        }

        public virtual async Task<int> HardDelete(int id)
        {
            var entityToDelete = await this.Find(id);

            return await this.HardDelete(entityToDelete);
        }

        public virtual async Task<int> Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;

            return await this.context.SaveChangesAsync(default(CancellationToken));
        }

        public virtual async Task<int> HardDelete(T entity)
        {
            this.Set.Remove(entity);

            return await this.context.SaveChangesAsync(default(CancellationToken));
        }

        public virtual async Task<T> Find(int id)
        {
            return await this.Set.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public virtual async Task<T> FindByCreationDate(DateTime creationDate)
        {
            return await this.Set.FirstOrDefaultAsync(x => x.CreatedOn == creationDate);
        }

        public virtual IQueryable<T> GetAll()
        {
            return this.Set.Where(x => !x.IsDeleted);
        }

        public virtual IQueryable<T> GetAllWithDeleted()
        {
            return this.Set;
        }

        public virtual async Task<int> Update()
        {
            return await this.context.SaveChangesAsync(default(CancellationToken));
        }
    }
}
