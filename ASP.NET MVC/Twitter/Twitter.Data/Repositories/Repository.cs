using System;
using System.Data.Entity;
using System.Linq;

using Twitter.Data.Interfaces;
using Twitter.Models;

namespace Twitter.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel<int>
    {
        private DbContext context;
        private IDbSet<T> dbSet;

        public Repository(DbContext context)
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

        public void Add(T entity)
        {
            this.dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
        }

        public void HardDelete(T entity)
        {
            this.dbSet.Remove(entity);
        }

        public T Find(object id)
        {
            return this.dbSet.Find(id);
        }

        public T FindByCreationDate(DateTime creationDate)
        {
            return this.dbSet.FirstOrDefault(x => x.CreatedOn == creationDate);
        }

        public IQueryable<T> GetAll()
        {
            return this.dbSet.Where(x => !x.IsDeleted);
        }

        public IQueryable<T> GetAllWithDeleted()
        {
            return this.dbSet;
        }

        public void Update(T entity)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }
    }
}
