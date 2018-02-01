using System.Data.Entity;

using BookShopSystem.Models;
using BookShopSystem.Data.Migrations;

namespace BookShopSystem.Data
{
    public class BookShopContext : DbContext
    {
        public BookShopContext()
            : base("BookShopContext")
        {
            IDatabaseInitializer<BookShopContext> migrationStrategy = 
                new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Category> Categories { get; set; }

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