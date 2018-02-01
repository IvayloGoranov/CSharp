using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

using Fruits.Models;
using Fruits.Models.Interfaces;
using Fruits.Data.Interfaces;

namespace Fruits.Data
{
    public class FruitsContext : DbContext, IFruitsContext
    {
        public FruitsContext(string connectionString)
            : base(connectionString)
        {
        }

        public IDbSet<Fruit> Fruits { get; set; }

        public override int SaveChanges()
        {
            this.SetDateTimeToNewlyCreatedOrModifiedEntities();

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync()
        {
            this.SetDateTimeToNewlyCreatedOrModifiedEntities();

            return await base.SaveChangesAsync();
        }

        private void SetDateTimeToNewlyCreatedOrModifiedEntities()
        {
            var addedOrModifiedEntities = this.ChangeTracker.Entries()
                        .Where(
                        e =>
                        e.Entity is IModifiableEntity &&
                        ((e.State == EntityState.Added) || (e.State == EntityState.Modified)));

            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in addedOrModifiedEntities)
            {
                var entity = (IModifiableEntity)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}