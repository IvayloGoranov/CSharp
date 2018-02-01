using System.Data.Entity.Migrations;

using OnlineShop.Models;

namespace OnlineShop.Data.Migrations
{
    public sealed class DbMigrationsConfig : DbMigrationsConfiguration<OnlineShopContext>
    {
        public DbMigrationsConfig()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(OnlineShopContext context)
        {
        }
    }
}
