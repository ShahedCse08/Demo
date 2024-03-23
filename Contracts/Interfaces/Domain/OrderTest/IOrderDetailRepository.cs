using Entities.Models.OrderTest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Domain.OrderTest
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetAllOrderDetailsAsync(bool trackChanges);
        Task<OrderDetail> GetOrderDetailAsync(int orderDetailId, bool trackChanges);
        Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId, bool trackChanges);
        void CreateOrderDetail(OrderDetail orderDetail);
        void DeleteOrderDetail(OrderDetail orderDetail);
    }
}
