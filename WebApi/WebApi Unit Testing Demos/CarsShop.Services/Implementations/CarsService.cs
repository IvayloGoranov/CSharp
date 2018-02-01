using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarsShop.Models;
using CarsShop.Models.BindingModels;
using CarsShop.Models.Entities;
using CarsShop.Models.ViewModels;
using CarsShop.Services.Interfaces;
using CarShop.Data.Interfaces;

namespace CarsShop.Services.Implementations
{
    public class CarsService : Service, ICarsService
    {                            
        public CarsService(ICarsDbContext cars)
            : base(cars)
        {
        }

        public IEnumerable<CarVm> GetAllCars()
        {
            IEnumerable<Car> models = this.Context.Cars.AsEnumerable();
            IEnumerable<CarVm> vms = Mapper.Instance
                .Map<IEnumerable<Car>, IEnumerable<CarVm>>(models);
            return vms;
        }

        public bool ContainsCar(int id)
        {
            return this.Context.Cars.Find(id) != null;
        }

        public CarVm GetCarById(int id)
        {
            Car model = this.Context.Cars.Find(id);
            CarVm vm = Mapper.Instance.Map<Car, CarVm>(model);
            return vm;
        }

        public void Add(CarBm car)
        {
            Car model = Mapper.Instance.Map<CarBm, Car>(car);
            this.Context.Cars.Add(model);
            this.Context.SaveChanges();
        }

        public void Edit(int id, CarBm bind)
        {
            Car model = this.Context.Cars.Find(id);
            model.Name = bind.Name;
            model.Price = bind.Price;
            this.Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Car model = this.Context.Cars.Find(id);
            this.Context.Cars.Remove(model);
            this.Context.SaveChanges();
        }
    }
}

