namespace FluentMvc.App
{
    using BugTracker.Data;
    using System.Data.Entity;

    public class BugTrackerContext : DbContext
    {

        public BugTrackerContext()
            : base("name=BugTrackerContext")
        {
        }

        public virtual DbSet<Bug> Bugs { get; set; }
    }

}