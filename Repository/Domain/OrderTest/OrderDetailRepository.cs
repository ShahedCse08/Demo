using Contracts.Interfaces.Domain.OrderTest;
using Entities.Context;
using Entities.Models.OrderTest;
using Microsoft.EntityFrameworkCore;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Domain.OrderTest
{
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetailsAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<OrderDetail> GetOrderDetailAsync(int orderDetailId, bool trackChanges) =>
            await FindByCondition(od => od.OrderDetailId.Equals(orderDetailId), trackChanges)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId, bool trackChanges) =>
            await FindByCondition(od => od.OrderId.Equals(orderId), trackChanges).ToListAsync();

        public void CreateOrderDetail(OrderDetail orderDetail) => Create(orderDetail);

        public void DeleteOrderDetail(OrderDetail orderDetail) => Delete(orderDetail);
    }
}
