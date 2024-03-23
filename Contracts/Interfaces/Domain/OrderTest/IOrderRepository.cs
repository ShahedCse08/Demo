using Entities.Models.OrderTest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Domain.OrderTest
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync(bool trackChanges);
        Task<Order> GetOrderAsync(int orderId, bool trackChanges);
        Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId, bool trackChanges);
        void CreateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
