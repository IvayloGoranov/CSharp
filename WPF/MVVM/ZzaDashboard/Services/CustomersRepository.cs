using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDashboard.Services
{
    public class CustomersRepository : ICustomersRepository
    {
        private ZzaDbContext context = new ZzaDbContext();

        public Task<List<Customer>> GetCustomersAsync()
        {
            return this.context.Customers.ToListAsync();
        }

        public Task<Customer> GetCustomerAsync(Guid id)
        {
            return this.context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            this.context.Customers.Add(customer);
            await this.context.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            if (!this.context.Customers.Local.Any(c => c.Id == customer.Id))
            {
                this.context.Customers.Attach(customer);
            }

            this.context.Entry(customer).State = EntityState.Modified;
            await this.context.SaveChangesAsync();

            return customer;
        }

        public async Task DeleteCustomerAsync(Guid customerId)
        {
            var customer = context.Customers.FirstOrDefault(c => c.Id == customerId);
            if (customer != null)
            {
                this.context.Customers.Remove(customer);
            }

            await this.context.SaveChangesAsync();
        }
    }
}
