using System.Data.Entity.Migrations;

namespace MassDefect.Data.Migrations
{
    public sealed class DbMigrationsConfig : DbMigrationsConfiguration<MassDefectContext>
    {
        public DbMigrationsConfig()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MassDefectContext context)
        {
        }
    }
}
