using CarsShop.Models.Entities;
using System.Data.Entity;

namespace CarShop.Data.Interfaces
{
    public interface ICarsDbContext
    {
        DbSet<Car> Cars { get; set; }

        int SaveChanges();
    }
}
