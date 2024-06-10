using Entities.DataTransferObjects.Retrieve;
using Entities.Models.PurchaseOrders;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Domain.PurchaseOrders
{
    public interface IPurchaseOrderRepository
    {
        Task<PagedList<PurchaseOrderDto>> GetPurchaseOrdersAsync(PurchaseOrderParameters purchaseOrderParameters, bool trackChanges);

        Task CreatePurhcaseOrder(PurchaseOrder purchaseOrder, IEnumerable<PurchaseOrderDetail> purchaseOrderDetail);

    }
}
