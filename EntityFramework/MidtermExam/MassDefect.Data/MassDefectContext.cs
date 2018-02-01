using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using MassDefect.Models;

namespace MassDefect.Data
{
    public class MassDefectContext : DbContext
    {
        public MassDefectContext()
            : base("name=MassDefectContext")
        {
        }

        public IDbSet<Anomaly> Anomalies { get; set; }

        public IDbSet<Person> Persons { get; set; }

        public IDbSet<Planet> Planets { get; set; }

        public IDbSet<SolarSystem> SolarSystems { get; set; }

        public IDbSet<Star> Stars { get; set; }

        public IDbSet<Sun> Suns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Anomaly>()
                .HasMany<Person>(x => x.Persons)
                .WithMany(x => x.Anomalies)
                .Map(x =>
                {
                    x.MapLeftKey("AnomalyId");
                    x.MapRightKey("PersonId");
                    x.ToTable("AnomalyVictims");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}