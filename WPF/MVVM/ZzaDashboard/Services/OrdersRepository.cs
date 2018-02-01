using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Zza.Data;
namespace ZzaDashboard.Services
{
    public class OrdersRepository : IOrdersRepository
    {
        private ZzaDbContext context = new ZzaDbContext();

        public async Task<List<Order>> GetOrdersForCustomersAsync(Guid customerId)
        {
            return await this.context.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await this.context.Orders.ToListAsync();
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            this.context.Orders.Add(order);

            await this.context.SaveChangesAsync();

            return order;
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            if (!this.context.Orders.Local.Any(o => o.Id == order.Id))
            {
                this.context.Orders.Attach(order);
            }

            this.context.Entry(order).State = EntityState.Modified;

            await this.context.SaveChangesAsync();

            return order;
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var order = this.context.Orders.Include("OrderItems").
                    Include("OrderItems.OrderItemOptions").FirstOrDefault(o => o.Id == orderId);
                if (order != null)
                {
                    foreach (OrderItem item in order.OrderItems)
                    {
                        foreach (var orderItemOption in item.Options)
                        {
                            this.context.OrderItemOptions.Remove(orderItemOption);
                        }

                        this.context.OrderItems.Remove(item);
                    }

                    this.context.Orders.Remove(order);
                }

                await this.context.SaveChangesAsync();
                scope.Complete();
            }
        }


        public async Task<List<Product>> GetProductsAsync()
        {
            return await this.context.Products.ToListAsync();
        }

        public async Task<List<ProductOption>> GetProductOptionsAsync()
        {
            return await this.context.ProductOptions.ToListAsync();
        }

        public async Task<List<ProductSize>> GetProductSizesAsync()
        {
            return await this.context.ProductSizes.ToListAsync();
        }

        public async Task<List<OrderStatus>> GetOrderStatusesAsync()
        {
            return await this.context.OrderStatuses.ToListAsync();
        }
    }
}
