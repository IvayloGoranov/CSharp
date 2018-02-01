using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarDealer.Models.BindingModels.Customers;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels.Customers;

namespace CarDealer.Services
{
    public class CustomersService : Service
    {
        public IEnumerable<AllCustomerVm> GetAllOrderedCustomers(string order)
        {
            IEnumerable<Customer> customers;
            if (order == "ascending")
            {
                customers =
                    this.Context.Customers.OrderBy(customer => customer.BirthDate)
                        .ThenBy(customer => customer.IsYoungDriver);
            }
            else if (order == "descending")
            {
                customers =
                    this.Context.Customers.OrderByDescending(customer => customer.BirthDate)
                        .ThenBy(customer => customer.IsYoungDriver);
            }
            else
            {
                throw new ArgumentException("The argument you have given for the order is invalid!");
            }

            IEnumerable<AllCustomerVm> viewModels =
                Mapper.Instance.Map<IEnumerable<Customer>, IEnumerable<AllCustomerVm>>(customers);

            return viewModels;
        }

        public AboutCustomerVm GetCustomerWithCarData(int id)
        {
            Customer customer = this.Context.Customers.Find(id);

            return new AboutCustomerVm()
            {
                Name = customer.Name,
                BoughtCarsCount = customer.Sales.Count,
                TotalSpentMoney = customer.Sales.Sum(sale => sale.Car.Parts.Sum(part => part.Price))
            };
        }

        public void AddCustomerBm(AddCustomerBm bind)
        {
            Customer customer = Mapper.Map<AddCustomerBm, Customer>(bind);
            if (DateTime.Now.Year - bind.BirthDate.Year < 21)
            {
                customer.IsYoungDriver = true;
            }

            this.Context.Customers.Add(customer);
            this.Context.SaveChanges();
        }

        public EditCustomerVm GetEditVm(int id)
        {
            Customer model = this.Context.Customers.Find(id);
            return Mapper.Map<Customer, EditCustomerVm>(model);
        }

        public void EditCustomer(EditCustomerBm bind)
        {
            Customer model = this.Context.Customers.Find(bind.Id);

            if (model == null)
            {
                throw new ArgumentException("Cannot find customer with such id!");
            }

            model.Name = bind.Name;
            model.BirthDate = bind.BirthDate;
            this.Context.SaveChanges();
        }
    }
}
