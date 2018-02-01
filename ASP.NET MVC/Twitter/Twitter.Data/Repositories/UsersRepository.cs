using System;
using System.Data.Entity;
using System.Linq;

using Twitter.Data.Interfaces;
using Twitter.Models;

namespace Twitter.Data.Repositories
{
    public class UsersRepository : IRepository<User>
    {
        private DbContext context;
        private IDbSet<User> dbSet;

        public UsersRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<User>();
        }

        public IDbSet<User> Set
        {
            get
            {
                return this.dbSet;
            }
        }

        public void Add(User entity)
        {
            this.dbSet.Add(entity);
        }

        public void Delete(User entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
        }

        public void HardDelete(User entity)
        {
            this.dbSet.Remove(entity);
        }

        public User Find(object id)
        {
            return this.dbSet.Find(id);
        }

        public User FindByCreationDate(DateTime creationDate)
        {
            return this.dbSet.FirstOrDefault(x => x.CreatedOn == creationDate);
        }

        public IQueryable<User> GetAll()
        {
            return this.dbSet.Where(x => !x.IsDeleted);
        }

        public IQueryable<User> GetAllWithDeleted()
        {
            return this.dbSet;
        }

        public void Update(User entity)
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
