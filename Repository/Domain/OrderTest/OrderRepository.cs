using Contracts.Interfaces.Domain.OrderTest;
using Entities.Context;
using Entities.Models.OrderTest;
using Microsoft.EntityFrameworkCore;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Domain.OrderTest
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

        public async Task<Order> GetOrderAsync(int orderId, bool trackChanges) =>
            await FindByCondition(o => o.OrderId.Equals(orderId), trackChanges)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId, bool trackChanges) =>
            await FindByCondition(o => o.CustomerId.Equals(customerId), trackChanges)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

        public void CreateOrder(Order order) => Create(order);

        public void DeleteOrder(Order order) => Delete(order);
    }
}
