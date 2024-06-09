using Entities.Models.PurchaseOrders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasData(
                new Supplier
                {
                    SupplierId = 1,
                    Name = "Insight",
                    Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                },

                new Supplier
                {
                    SupplierId = 2,
                    Name = "Micro Center",
                    Address = "312 Forest Avenue, BF 923",
                },

                new Supplier
                {
                    SupplierId = 3,
                    Name = "Computer Source",
                    Address = "345 Street Forest Avenue, BF 923",
                }
                );
        }
    }
}
