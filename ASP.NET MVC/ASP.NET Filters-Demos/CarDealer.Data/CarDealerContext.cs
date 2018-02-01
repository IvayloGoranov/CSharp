using System.Data.Entity;
using CarDealer.Models.EntityModels;

namespace CarDealer.Data
{
    public class CarDealerContext : DbContext
    {
        public CarDealerContext()
            : base("CarDealerContext")
        {
            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<Part> Parts { get; set; }

        public virtual DbSet<Supplier> Suppliers { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Sale> Sales { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Login> Logins { get; set; }

        public virtual DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasMany<Part>(car => car.Parts).WithMany(part => part.Cars);
            modelBuilder.Entity<Supplier>().HasMany<Part>(supplier => supplier.Parts).WithRequired(part => part.Supplier).WillCascadeOnDelete(true);
        }
    }

}