using System.Data.Entity.Migrations;

namespace FootballBetting.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<FootballBettingContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(FootballBettingContext context)
        {
        }
    }
}
