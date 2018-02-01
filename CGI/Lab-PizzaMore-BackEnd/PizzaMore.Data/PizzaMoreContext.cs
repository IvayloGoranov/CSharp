using System.Data.Entity;

namespace PizzaMore.Data
{
    public class PizzaMoreContext : DbContext
    {
        public PizzaMoreContext()
            : base("name=PizzaMoreContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Session> Sessions { get; set; }

        public virtual DbSet<Pizza> PizzaSuggestions { get; set; }
    }
}