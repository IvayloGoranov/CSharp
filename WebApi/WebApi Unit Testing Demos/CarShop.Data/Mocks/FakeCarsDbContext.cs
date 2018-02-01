using System.Data.Entity;
using CarsShop.Models.Entities;
using CarShop.Data.Interfaces;

namespace CarShop.Data.Mocks
{
    public class FakeCarsDbContext : ICarsDbContext
    {
        public FakeCarsDbContext()
        {
            this.Cars = new FakeCarsDbSet();
        }      

        public DbSet<Car> Cars { get; set; }
        public int SaveChanges()
        {
            return 0;
        }
    }
}
