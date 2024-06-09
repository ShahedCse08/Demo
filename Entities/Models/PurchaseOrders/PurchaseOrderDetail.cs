using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models.PurchaseOrders
{
    public class PurchaseOrderDetail
    {
        public int PurchaseOrderDetailId { get; set; }
        public int OrderId { get; set; }  
        public int LineItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
    }
}
