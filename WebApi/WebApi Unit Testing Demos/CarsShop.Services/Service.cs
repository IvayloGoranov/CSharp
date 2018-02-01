using System.Collections.Generic;
using CarsShop.Models;
using CarsShop.Models.Entities;
using CarShop.Data.Interfaces;

namespace CarsShop.Services
{
    public abstract class Service
    {
        public Service(ICarsDbContext context)
        {
            this.Context = context;
        }

        protected ICarsDbContext Context { get; }
    }
}
