using Contracts.Interfaces.Domain.PurchaseOrder;
using Entities.Context;
using Entities.Models.PurchaseOrders;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Domain.PurchaseOrders
{
    public class PurchaseOrderRepository : RepositoryBase<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
