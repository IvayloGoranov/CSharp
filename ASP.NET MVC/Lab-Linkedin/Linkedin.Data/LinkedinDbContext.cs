using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

using Linkedin.Models;
using Linkedin.Data.Migrations;

namespace Linkedin.Data
{
    public class LinkedinDbContext : IdentityDbContext<ApplicationUser>, ILinkedInDbContext
    {
        public LinkedinDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<LinkedinDbContext, Configuration>());
        }

        public IDbSet<Certification> Certifications { get; set; }

        public IDbSet<Discussion> Discussions { get; set; }

        public IDbSet<Experience> Experiences { get; set; }

        public IDbSet<Group> Groups { get; set; }

        public IDbSet<UserLanguage> UserLanguages { get; set; }

        public IDbSet<Project> Projects { get; set; }

        public IDbSet<Skill> Skill { get; set; }

        public IDbSet<Endorsement> Endorsements { get; set; }

        public IDbSet<AdministrationLog> AdministrationLogs { get; set; }

        public static LinkedinDbContext Create()
        {
            return new LinkedinDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Endorsement>().HasRequired(x => x.UserSkill).
                WithMany(x => x.Endorsements).WillCascadeOnDelete(false);
            modelBuilder.Entity<Group>().HasRequired(x => x.Owner).WithOptional().
                WillCascadeOnDelete(false);
            modelBuilder.Entity<Experience>().HasRequired(x => x.User).
                WithMany(x => x.Experiences).WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
