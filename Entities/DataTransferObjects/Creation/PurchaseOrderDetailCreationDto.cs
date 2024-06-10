using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.Creation
{
    public class PurchaseOrderDetailCreationDto
    {
        public int LineItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
    }
}
