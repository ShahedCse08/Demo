using Entities.Models.PurchaseOrders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models.OrderTest
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Vat { get; set; }
        public decimal VatAddedPrice { get; set; }
        public decimal VatExcludedPrice { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
