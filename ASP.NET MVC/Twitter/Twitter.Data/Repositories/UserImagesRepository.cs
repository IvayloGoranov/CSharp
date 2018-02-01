using System;
using System.Data.Entity;
using System.Linq;

using Twitter.Data.Interfaces;
using Twitter.Models;

namespace Twitter.Data.Repositories
{
    public class UserImagesRepository : IRepository<UserImage>
    {
        private DbContext context;
        private IDbSet<UserImage> dbSet;

        public UserImagesRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<UserImage>();
        }

        public IDbSet<UserImage> Set
        {
            get
            {
                return this.dbSet;
            }
        }

        public void Add(UserImage entity)
        {
            this.dbSet.Add(entity);
        }

        public void Delete(UserImage entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
        }

        public void HardDelete(UserImage entity)
        {
            this.dbSet.Remove(entity);
        }

        public UserImage Find(object id)
        {
            return this.dbSet.Find(id);
        }

        public UserImage FindByCreationDate(DateTime creationDate)
        {
            return this.dbSet.FirstOrDefault(x => x.CreatedOn == creationDate);
        }

        public IQueryable<UserImage> GetAll()
        {
            return this.dbSet.Where(x => !x.IsDeleted);
        }

        public IQueryable<UserImage> GetAllWithDeleted()
        {
            return this.dbSet;
        }

        public void Update(UserImage entity)
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
