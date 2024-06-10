using Contracts.Interfaces.Domain.PurchaseOrders;
using Entities.Context;
using Entities.DataTransferObjects.Retrieve;
using Entities.Models;
using Entities.Models.PurchaseOrders;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Domain.PurchaseOrders
{
    public class PurchaseOrderRepository : RepositoryBase<PurchaseOrder>, IPurchaseOrderRepository
    {
        private readonly RepositoryContext _context;
        public PurchaseOrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _context = repositoryContext;
        }

        public async Task CreatePurhcaseOrder(PurchaseOrder purchaseOrder, IEnumerable<PurchaseOrderDetail> purchaseOrderDetails)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    purchaseOrder = await CreateAndReturnAsync(purchaseOrder);

                    foreach (var purchaseOrderDetail in purchaseOrderDetails)
                    {
                        purchaseOrderDetail.PurchaseOrderId = purchaseOrder.PurchaseOrderId;
                        _context.Set<PurchaseOrderDetail>().Add(purchaseOrderDetail);
                    }

                    await _context.SaveChangesAsync(); // Assuming you're using Entity Framework Core
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    // Handle exception
                    throw;
                }
            }
        }

        public async Task<PagedList<PurchaseOrderDto>> GetPurchaseOrdersAsync(PurchaseOrderParameters purchaseOrderParameters, bool trackChanges)
        {

            var purchaseOrders = FindAll(trackChanges);
            var suppliers = _context.Suppliers;
            var query = from purchaseOrder in purchaseOrders
                        join supplier in suppliers on purchaseOrder.SupplierId equals supplier.SupplierId
                        select new PurchaseOrderDto
                        {
                            PurchaseOrderId = purchaseOrder.PurchaseOrderId,
                            ReferenceId = purchaseOrder.ReferenceId,
                            PurchaseOrderNumber = purchaseOrder.PurchaseOrderNumber,
                            PurchaseOrderDate = purchaseOrder.PurchaseOrderDate,
                            Supplier = supplier.Name,
                            ExpectedDate = purchaseOrder.ExpectedDate,
                            Remarks = purchaseOrder.Remarks,
                        };

            var result = await query.Search(purchaseOrderParameters.SearchTerm).ToListAsync();

            return PagedList<PurchaseOrderDto>.ToPagedList(result, purchaseOrderParameters.PageNumber,
            purchaseOrderParameters.PageSize);

        }

    }
}
