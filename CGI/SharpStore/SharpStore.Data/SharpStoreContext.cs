using SharpStore.Data.Models;

namespace SharpStore.Data
{
    using System.Data.Entity;

    public class SharpStoreContext : DbContext
    {
        public SharpStoreContext()
            : base("SharpStoreContext")
        {
        }

        public DbSet<Knive> Knives { get; set; }

        public DbSet<Message> Messages { get; set; }

    }
}