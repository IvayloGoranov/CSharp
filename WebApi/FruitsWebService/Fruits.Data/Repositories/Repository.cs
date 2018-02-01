using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using Fruits.Data.Interfaces;
using Fruits.Models;

namespace Fruits.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel<int>
    {
        private IFruitsContext context;
        private IDbSet<T> dbSet;

        public Repository(IFruitsContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public IDbSet<T> Set
        {
            get
            {
                return this.dbSet;
            }
        }

        public virtual async Task<int> Add(T entity)
        {
            this.Set.Add(entity);

            return await this.context.SaveChangesAsync();
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

            return await this.context.SaveChangesAsync();
        }

        public virtual async Task<int> HardDelete(T entity)
        {
            this.Set.Remove(entity);

            return await this.context.SaveChangesAsync();
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

        public virtual async Task<int> Update(T entity)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.Set.Attach(entity);
            }

            entry.State = EntityState.Modified;

            return await this.context.SaveChangesAsync();
        }
    }
}
