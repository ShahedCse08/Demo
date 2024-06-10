using Entities.DataTransferObjects.Retrieve;
using Entities.Models;
using Entities.Models.PurchaseOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Extensions
{
    public static class RepositoryPurchaseOrderExtensions
    {
        public static IQueryable<PurchaseOrderDto> Search(this IQueryable<PurchaseOrderDto> purchaseOrders, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return purchaseOrders;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return purchaseOrders.Where(e => e.PurchaseOrderNumber.ToLower().Contains(lowerCaseTerm) 
               || e.Supplier.ToLower().Contains(lowerCaseTerm) 
            );
        }
    }
}
