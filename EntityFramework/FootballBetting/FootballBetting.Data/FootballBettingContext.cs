using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

using FootballBetting.Models;
using FootballBetting.Models.Interfaces;
using System;

namespace FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
            : base("name=FootballBettingContext")
        {
        }

        public IDbSet<Bet> Bets { get; set; }

        public IDbSet<Color> Colors { get; set; }

        public IDbSet<Competition> Competitions { get; set; }

        public IDbSet<CompetitionType> CompetitionTypes { get; set; }

        public IDbSet<Continent> Continents { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Match> Matches { get; set; }

        public IDbSet<MatchBet> MatchBets { get; set; }

        public IDbSet<Player> Players { get; set; }

        public IDbSet<PlayerStatistics> PlayersStatistics { get; set; }

        public IDbSet<ResultPrediction> ResultPredictions { get; set; }

        public IDbSet<Round> Rounds { get; set; }

        public IDbSet<Team> Teams { get; set; }

        public IDbSet<Town> Towns { get; set; }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Player>()
                .HasMany<Position>(x => x.Positions)
                .WithMany(x => x.Players)
                .Map(x =>
                {
                    x.MapLeftKey("PlayerId");
                    x.MapRightKey("PositionId");
                    x.ToTable("Players_Positions");
                });

            modelBuilder.Entity<Country>()
                .HasMany<Continent>(x => x.Continents)
                .WithMany(x => x.Countries)
                .Map(x =>
                {
                    x.MapLeftKey("CountryId");
                    x.MapRightKey("ContinentId");
                    x.ToTable("Countries_Continents");
                });

            //modelBuilder.Entity<PlayerStatistics>().HasRequired(x => x.Player)
            //                     .WithMany(x => x.Statistics).HasForeignKey(m => m.PlayerId);
            //modelBuilder.Entity<PlayerStatistics>().HasRequired(x => x.Match)
            //                            .WithMany().HasForeignKey(x => x.MatchId);

            //modelBuilder.Entity<MatchBet>().HasRequired(x => x.Match)
            //                     .WithMany(x => x.MatchBets).HasForeignKey(m => m.MatchId);
            //modelBuilder.Entity<MatchBet>().HasRequired(x => x.Bet)
            //                            .WithMany().HasForeignKey(x => x.BetId);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IModifiableEntity && ((e.State == EntityState.Added) || 
                        (e.State == EntityState.Modified))))
            {
                var entity = (IModifiableEntity)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}