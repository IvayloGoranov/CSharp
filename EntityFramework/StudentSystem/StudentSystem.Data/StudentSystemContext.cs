using System.Data.Entity;

using StudentSystem.Models;
using StudentSystem.Data.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("StudentSystemContext")
        {
            IDatabaseInitializer<StudentSystemContext> migrationStrategy =
                new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Resource> Resources { get; set; }

        public IDbSet<License> Licenses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions
                .Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}