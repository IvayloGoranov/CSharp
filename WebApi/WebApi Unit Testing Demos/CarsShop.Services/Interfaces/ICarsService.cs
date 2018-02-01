using System.Collections.Generic;
using CarsShop.Models.BindingModels;
using CarsShop.Models.ViewModels;

namespace CarsShop.Services.Interfaces
{
    public interface ICarsService
    {
        IEnumerable<CarVm> GetAllCars();
        bool ContainsCar(int id);
        CarVm GetCarById(int id);
        void Add(CarBm car);
        void Edit(int id, CarBm bind);
        void Delete(int id);
    }
}
