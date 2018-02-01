namespace Events.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public IDbSet<Event> Events { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
