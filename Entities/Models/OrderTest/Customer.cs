using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models.OrderTest
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        // Other customer information properties

        public virtual ICollection<Order> Orders { get; set; }
    }
}
