using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;

using Fruits.Web.IdentityData.Interfaces;
using Fruits.Models.Interfaces;

namespace Fruits.Web.IdentityData
{
    public class AppIdentityDbContext : IdentityDbContext<User>, IAppIdentityDbContext
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options)
        {
        }

        public DbSet<Subscription> Subscriptions { get; set; }

        public override int SaveChanges()
        {
            this.SetDateTimeToNewlyCreatedOrModifiedEntities();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.SetDateTimeToNewlyCreatedOrModifiedEntities();

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Subscription>().HasIndex(x => x.IsDeleted);
            builder.Entity<Subscription>().HasIndex(x => x.Name);

            builder.Entity<UserSubscription>().HasKey(x => new { x.UserId, x.SubscriptionId });

            builder.Entity<UserSubscription>()
                .HasOne(x => x.User)
                .WithMany(x => x.Subscriptions)
                .HasForeignKey(x => x.UserId);

            builder.Entity<UserSubscription>()
                .HasOne(x => x.Subscription)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.SubscriptionId);
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
