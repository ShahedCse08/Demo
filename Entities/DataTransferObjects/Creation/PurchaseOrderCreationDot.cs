using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.Creation
{
    public class PurchaseOrderCreationDto
    {
        public int ReferenceId { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public DateTime PurchaseOrderDate { get; set; }
        public int SupplierId { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string Remarks { get; set; }
    }
}
