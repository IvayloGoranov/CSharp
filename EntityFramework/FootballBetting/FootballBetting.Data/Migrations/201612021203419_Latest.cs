namespace FootballBetting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Latest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BetDateTime = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.MatchBets",
                c => new
                    {
                        MatchId = c.Int(nullable: false),
                        BetId = c.Int(nullable: false),
                        ResultPredictionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MatchId, t.BetId })
                .ForeignKey("dbo.Bets", t => t.BetId)
                .ForeignKey("dbo.Matches", t => t.MatchId)
                .ForeignKey("dbo.ResultPredictions", t => t.ResultPredictionId)
                .Index(t => t.MatchId)
                .Index(t => t.BetId)
                .Index(t => t.ResultPredictionId);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HomeTeamId = c.Int(nullable: false),
                        AwayTeamId = c.Int(nullable: false),
                        RoundId = c.Int(nullable: false),
                        CompetitionId = c.Int(nullable: false),
                        HomeTeamGoals = c.Int(nullable: false),
                        AwayTeamGoals = c.Int(nullable: false),
                        PlayedOn = c.DateTime(nullable: false),
                        HomeTeamWinBetRate = c.Double(nullable: false),
                        AwayTeamWinBetRate = c.Double(nullable: false),
                        DrawBetRate = c.Double(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.AwayTeamId)
                .ForeignKey("dbo.Teams", t => t.HomeTeamId)
                .ForeignKey("dbo.Competitions", t => t.CompetitionId)
                .ForeignKey("dbo.Rounds", t => t.RoundId)
                .Index(t => t.HomeTeamId)
                .Index(t => t.AwayTeamId)
                .Index(t => t.RoundId)
                .Index(t => t.CompetitionId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Initial = c.String(maxLength: 3),
                        PrimaryKitColorId = c.Int(nullable: false),
                        SecondaryColorId = c.Int(nullable: false),
                        TownId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 300),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colors", t => t.PrimaryKitColorId)
                .ForeignKey("dbo.Colors", t => t.SecondaryColorId)
                .ForeignKey("dbo.Towns", t => t.TownId)
                .Index(t => t.PrimaryKitColorId)
                .Index(t => t.SecondaryColorId)
                .Index(t => t.TownId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SquadNumber = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                        IsInjured = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 300),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamId)
                .Index(t => t.TeamId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(maxLength: 100),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.PlayerStatistics",
                c => new
                    {
                        PlayerId = c.Int(nullable: false),
                        MatchId = c.Int(nullable: false),
                        Goals = c.Int(nullable: false),
                        Assists = c.Int(nullable: false),
                        MinutesPlayed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlayerId, t.MatchId })
                .ForeignKey("dbo.Matches", t => t.MatchId)
                .ForeignKey("dbo.Players", t => t.PlayerId)
                .Index(t => t.PlayerId)
                .Index(t => t.MatchId);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 300),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryId = c.String(maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 300),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 300),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Continents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 300),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Competitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompetitionTypeId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 300),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompetitionTypes", t => t.CompetitionTypeId)
                .Index(t => t.CompetitionTypeId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.CompetitionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 300),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Rounds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 300),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.ResultPredictions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResultPredictionType = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        Email = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Players_Positions",
                c => new
                    {
                        PlayerId = c.Int(nullable: false),
                        PositionId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.PlayerId, t.PositionId })
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.Countries_Continents",
                c => new
                    {
                        CountryId = c.String(nullable: false, maxLength: 128),
                        ContinentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CountryId, t.ContinentId })
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Continents", t => t.ContinentId, cascadeDelete: true)
                .Index(t => t.CountryId)
                .Index(t => t.ContinentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bets", "UserId", "dbo.Users");
            DropForeignKey("dbo.MatchBets", "ResultPredictionId", "dbo.ResultPredictions");
            DropForeignKey("dbo.MatchBets", "MatchId", "dbo.Matches");
            DropForeignKey("dbo.Matches", "RoundId", "dbo.Rounds");
            DropForeignKey("dbo.Matches", "CompetitionId", "dbo.Competitions");
            DropForeignKey("dbo.Competitions", "CompetitionTypeId", "dbo.CompetitionTypes");
            DropForeignKey("dbo.Teams", "TownId", "dbo.Towns");
            DropForeignKey("dbo.Towns", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Countries_Continents", "ContinentId", "dbo.Continents");
            DropForeignKey("dbo.Countries_Continents", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Teams", "SecondaryColorId", "dbo.Colors");
            DropForeignKey("dbo.Teams", "PrimaryKitColorId", "dbo.Colors");
            DropForeignKey("dbo.Players", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.PlayerStatistics", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.PlayerStatistics", "MatchId", "dbo.Matches");
            DropForeignKey("dbo.Players_Positions", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Players_Positions", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Matches", "HomeTeamId", "dbo.Teams");
            DropForeignKey("dbo.Matches", "AwayTeamId", "dbo.Teams");
            DropForeignKey("dbo.MatchBets", "BetId", "dbo.Bets");
            DropIndex("dbo.Countries_Continents", new[] { "ContinentId" });
            DropIndex("dbo.Countries_Continents", new[] { "CountryId" });
            DropIndex("dbo.Players_Positions", new[] { "PositionId" });
            DropIndex("dbo.Players_Positions", new[] { "PlayerId" });
            DropIndex("dbo.Users", new[] { "IsDeleted" });
            DropIndex("dbo.ResultPredictions", new[] { "IsDeleted" });
            DropIndex("dbo.Rounds", new[] { "IsDeleted" });
            DropIndex("dbo.CompetitionTypes", new[] { "IsDeleted" });
            DropIndex("dbo.Competitions", new[] { "IsDeleted" });
            DropIndex("dbo.Competitions", new[] { "CompetitionTypeId" });
            DropIndex("dbo.Continents", new[] { "IsDeleted" });
            DropIndex("dbo.Countries", new[] { "IsDeleted" });
            DropIndex("dbo.Towns", new[] { "IsDeleted" });
            DropIndex("dbo.Towns", new[] { "CountryId" });
            DropIndex("dbo.Colors", new[] { "IsDeleted" });
            DropIndex("dbo.PlayerStatistics", new[] { "MatchId" });
            DropIndex("dbo.PlayerStatistics", new[] { "PlayerId" });
            DropIndex("dbo.Positions", new[] { "IsDeleted" });
            DropIndex("dbo.Players", new[] { "IsDeleted" });
            DropIndex("dbo.Players", new[] { "TeamId" });
            DropIndex("dbo.Teams", new[] { "IsDeleted" });
            DropIndex("dbo.Teams", new[] { "TownId" });
            DropIndex("dbo.Teams", new[] { "SecondaryColorId" });
            DropIndex("dbo.Teams", new[] { "PrimaryKitColorId" });
            DropIndex("dbo.Matches", new[] { "IsDeleted" });
            DropIndex("dbo.Matches", new[] { "CompetitionId" });
            DropIndex("dbo.Matches", new[] { "RoundId" });
            DropIndex("dbo.Matches", new[] { "AwayTeamId" });
            DropIndex("dbo.Matches", new[] { "HomeTeamId" });
            DropIndex("dbo.MatchBets", new[] { "ResultPredictionId" });
            DropIndex("dbo.MatchBets", new[] { "BetId" });
            DropIndex("dbo.MatchBets", new[] { "MatchId" });
            DropIndex("dbo.Bets", new[] { "IsDeleted" });
            DropIndex("dbo.Bets", new[] { "UserId" });
            DropTable("dbo.Countries_Continents");
            DropTable("dbo.Players_Positions");
            DropTable("dbo.Users");
            DropTable("dbo.ResultPredictions");
            DropTable("dbo.Rounds");
            DropTable("dbo.CompetitionTypes");
            DropTable("dbo.Competitions");
            DropTable("dbo.Continents");
            DropTable("dbo.Countries");
            DropTable("dbo.Towns");
            DropTable("dbo.Colors");
            DropTable("dbo.PlayerStatistics");
            DropTable("dbo.Positions");
            DropTable("dbo.Players");
            DropTable("dbo.Teams");
            DropTable("dbo.Matches");
            DropTable("dbo.MatchBets");
            DropTable("dbo.Bets");
        }
    }
}
