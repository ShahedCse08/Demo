using Entities.DataTransferObjects.Creation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.Manipulator
{
    public class PurchaseOrderWithDetailsUpdateDto
    {
        public PurchaseOrderUpdateDto PurchaseOrder { get; set; }
        public IEnumerable<PurchaseOrderDetailUpdateDto> PurchaseOrderDetails { get; set; }
    }
}
