namespace CameraBazaar.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CameraBazaarContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "CameraBazaar.Data.CameraBazaarContext";
        }

        protected override void Seed(CameraBazaarContext context)
        {  
        }
    }
}
