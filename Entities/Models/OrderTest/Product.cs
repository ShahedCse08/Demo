using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models.OrderTest
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        // Other product information properties

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
