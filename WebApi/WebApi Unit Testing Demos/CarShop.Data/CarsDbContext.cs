using CarsShop.Models.Entities;
using CarShop.Data.Interfaces;

namespace CarShop.Data
{
    using System.Data.Entity;

    public class CarsDbContext : DbContext, ICarsDbContext
    {                                                                                 
        public CarsDbContext()
            : base("CarsDb")
        {
        }

        public DbSet<Car> Cars { get; set; }
    }  
}