using System.Data.Entity.Migrations;

namespace BookShopSystem.Data.Migrations
{
    public sealed class DbMigrationsConfig : DbMigrationsConfiguration<BookShopContext>
    {
        public DbMigrationsConfig()
        {
            AutomaticMigrationsEnabled = true;
            this.ContextKey = "BookShopSystem.Data.BookShopContext";
        }

        protected override void Seed(BookShopContext context)
        {
        }
    }
}
