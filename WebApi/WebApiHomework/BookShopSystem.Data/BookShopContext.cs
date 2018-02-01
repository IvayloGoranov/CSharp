using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

using BookShopSystem.Models;
using BookShopSystem.Data.Migrations;
using BookShopSystem.Data.Interfaces;

namespace BookShopSystem.Data
{
    public class BookShopContext : IdentityDbContext<User>, IBookShopContext
    {
        public BookShopContext()
            : base("BookShopContext")
        {
            IDatabaseInitializer<BookShopContext> migrationStrategy = 
                new MigrateDatabaseToLatestVersion<BookShopContext, DbMigrationsConfig>();
            Database.SetInitializer(migrationStrategy);
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public static BookShopContext Create()
        {
            return new BookShopContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasMany(b => b.RelatedBooks).
                WithMany().
                Map(x =>
                {
                    x.MapLeftKey("BookId");
                    x.MapRightKey("RelatedBookId");
                    x.ToTable("Books_RelatedBooks");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}