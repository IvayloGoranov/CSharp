using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels;

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
    }
}
