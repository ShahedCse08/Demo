using Contracts.Interfaces.Domain.PurchaseOrder;
using Entities.Context;
using Entities.Models.PurchaseOrders;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Domain.PurchaseOrders
{
    public class PurchaseOrderDetailRepository : RepositoryBase<PurchaseOrderDetail>, IPurchaseOrderDetailRepository
    {
        public PurchaseOrderDetailRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
