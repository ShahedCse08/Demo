using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models.PurchaseOrders
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
