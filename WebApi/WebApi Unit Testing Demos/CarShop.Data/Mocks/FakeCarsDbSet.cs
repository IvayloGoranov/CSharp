using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsShop.Models.Entities;

namespace CarShop.Data.Mocks
{
    public class FakeCarsDbSet : FakeDbSet<Car>
    {
        public override Car Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(car => car.Id == wantedId);
        }
    }
}
