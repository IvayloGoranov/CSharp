namespace CameraBazaar.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Cameras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Make = c.Int(nullable: false),
                        Model = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 16, scale: 2),
                        Quantity = c.Int(nullable: false),
                        MinShutterSpeed = c.Int(nullable: false),
                        MaxShutterSpeed = c.Int(nullable: false),
                        MinIso = c.Int(nullable: false),
                        MaxIso = c.Int(nullable: false),
                        IsFullFrame = c.Boolean(nullable: false),
                        VideoResolution = c.String(nullable: false, maxLength: 15),
                        LightMetering = c.Int(nullable: false),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);

            this.CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);

            this.CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.Logins", "User_Id", "dbo.Users");
            this.DropForeignKey("dbo.Cameras", "User_Id", "dbo.Users");
            this.DropIndex("dbo.Logins", new[] { "User_Id" });
            this.DropIndex("dbo.Cameras", new[] { "User_Id" });
            this.DropTable("dbo.Users");
            this.DropTable("dbo.Logins");
            this.DropTable("dbo.Cameras");
        }
    }
}
