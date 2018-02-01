using System;
using System.Collections.Generic;
using System.Linq;

using ProductsAndCategories.Data.Interfaces;

namespace ProductsAndCategories.Data
{
    public abstract class ManagerBase<TEntity> : IManager<TEntity> where TEntity : class, IEntityBase, new()
    {
        protected readonly ProductsAndCategoriesDataContext context = new ProductsAndCategoriesDataContext();

        public virtual TEntity Get(int id)
        {
            return this.context.GetTable<TEntity>().SingleOrDefault(x => x.ID.Equals(id) && !x.IsDeleted);
        }

        public virtual IQueryable<TEntity> List()
        {
            return this.context.GetTable<TEntity>().Where(w => !w.IsDeleted);
        }

        public virtual void Delete(int id)
        {
            var entityToDelete = context.GetTable<TEntity>().SingleOrDefault(x => x.ID.Equals(id));
            if (entityToDelete == null)
            {
                throw new KeyNotFoundException(string.Format("No entry with id {0} found in the database", id));
            }

            entityToDelete.IsDeleted = true;
            this.context.SubmitChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            var entityToDelete = context.GetTable<TEntity>().SingleOrDefault(x => x.ID.Equals(entity.ID));
            if (entityToDelete == null)
            {
                throw new KeyNotFoundException(string.Format("No entry with id {0} found in the database", entity.ID));
            }

            entityToDelete.IsDeleted = true;
            this.context.SubmitChanges();
        }

        public virtual void Delete(IEnumerable<int> ids)
        {
            var entititesToDelete = context.GetTable<TEntity>().Where(x => ids.Contains(x.ID)).ToList();
            foreach (TEntity entity in entititesToDelete)
            {
                entity.IsDeleted = true;
            }

            this.context.SubmitChanges();
        }

        public virtual int GetCount()
        {
            return this.context.GetTable<TEntity>().Where(w => !w.IsDeleted).Count();
        }

        public virtual TEntity Save(TEntity entity)
        {
            if (entity.ID == 0)
            {
                // Invoke delegate on Insert
                return this.OnInsert(entity);
            }
            else
            {
                // Invoke delegate on Update
                return this.OnUpdate(entity);
            }
        }

        protected virtual TEntity OnInsert(TEntity entity)
        {
            if (entity is IEntityDateAttributes)
            {
                ((IEntityDateAttributes)entity).CreatedDate = DateTime.UtcNow;
            }

            this.context.GetTable<TEntity>().InsertOnSubmit(entity);
            this.context.SubmitChanges();

            return entity;
        }

        protected virtual TEntity OnUpdate(TEntity entity)
        {
            if (entity is IEntityDateAttributes)
            {
                ((IEntityDateAttributes)entity).ModifiedDate = DateTime.UtcNow;
            }

            this.context.SubmitChanges();

            return entity;
        }
    }
}
