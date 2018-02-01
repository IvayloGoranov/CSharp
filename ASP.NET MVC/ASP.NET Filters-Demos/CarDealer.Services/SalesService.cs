using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarDealer.Models.BindingModels.Sales;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels.Sales;

namespace CarDealer.Services
{
    public class SalesService : Service
    {
        public IEnumerable<SaleVm> GetAllSales()
        {
            IEnumerable<Sale> sales = this.Context.Sales;

            IEnumerable<SaleVm> saleVms = Mapper.Map<IEnumerable<Sale>, IEnumerable<SaleVm>>(sales);
            return saleVms;
        }

        public SaleVm GetSale(int id)
        {
            Sale sale = this.Context.Sales.Find(id);

            SaleVm vm = Mapper.Map<Sale, SaleVm>(sale);
            return vm;
        }

        public IEnumerable<SaleVm> GetDiscountedSales(double? percent)
        {
            percent /= 100;
            IEnumerable<Sale> sales = this.Context.Sales.Where(sale => sale.Discount != 0);

            if (percent != null)
            {
                sales = sales.Where(sale => sale.Discount == percent.Value);
            }

            IEnumerable<SaleVm> vms = Mapper.Map<IEnumerable<Sale>, IEnumerable<SaleVm>>(sales);
            return vms;
        }

        public AddSaleVm GetSalesVm()
        {
            AddSaleVm vm = new AddSaleVm();
            IEnumerable<Car> carModels = this.Context.Cars;
            IEnumerable<Customer> customerModels = this.Context.Customers;

            IEnumerable<AddSaleCarVm> carVms = Mapper.Map<IEnumerable<Car>, IEnumerable<AddSaleCarVm>>(carModels);
            IEnumerable<AddSaleCustomerVm> customerVms =
                Mapper.Map<IEnumerable<Customer>, IEnumerable<AddSaleCustomerVm>>(customerModels);

            List<int> discounts = new List<int>();
            for (int i = 0; i <= 50; i += 5)
            {
                discounts.Add(i);
            }

            vm.Cars = carVms;
            vm.Customers = customerVms;
            vm.Discounts = discounts;

            return vm;
        }

        public AddSaleConfirmationVm GetSaleCofirmationVm(AddSaleBm bind)
        {
            Car carModel = this.Context.Cars.Find(bind.CarId);
            Customer customerModel = this.Context.Customers.Find(bind.CustomerId);
            AddSaleConfirmationVm vm = new AddSaleConfirmationVm()
            {
                Discount = bind.Discount,
                CarPrice = (decimal)carModel.Parts.Sum(part => part.Price).Value,
                CarId = carModel.Id,
                CarRepresentation = $"{carModel.Make} {carModel.Model}",
                CustomerId = customerModel.Id,
                CustomerName = customerModel.Name
            };

            vm.Discount += customerModel.IsYoungDriver ? 5 : 0;
            vm.FinalCarPrice = vm.CarPrice - vm.CarPrice * vm.Discount / 100;
            return vm;
        }

        public void AddSale(AddSaleBm vm)
        {
            Car carModel = this.Context.Cars.Find(vm.CarId);
            Customer customerModel = this.Context.Customers.Find(vm.CustomerId);
            Sale sale = new Sale()
            {
                Customer = customerModel,
                Car = carModel,
                Discount = vm.Discount / 100.0
            };

            this.Context.Sales.Add(sale);
            this.Context.SaveChanges();
        }
    }
}
