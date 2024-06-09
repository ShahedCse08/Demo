using Entities.Models.OrderTest;
using Entities.Models.PurchaseOrders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Entities.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(

            new Product
            {
                ProductId = 1,
                Name = "Asus Vivobook i5",
                UnitPrice = 80
            },
            new Product
            {
                ProductId = 2,
                Name = "Asus Vivobook i7",
                UnitPrice = 90
            },
            new Product
            {
                ProductId = 3,
                Name = "Asus Vivobook i9",
                UnitPrice = 100
            },
            new Product
            {
                ProductId = 4,
                Name = "Lenovo IdeaPad Flex 5",
                UnitPrice = 110
            },
            new Product
            {
                ProductId = 5,
                Name = "Lenovo IdeaPad 1 AMD Ryzen 5",
                UnitPrice = 120
            },
            new Product
            {
                ProductId = 6,
                Name = "Apple MacBook Pro 14 inch M3",
                UnitPrice = 210
            },
            new Product
            {
                ProductId = 7,
                Name = "Apple MacBook Pro 15 inch M1",
                UnitPrice = 190
            },
            new Product
            {
                ProductId = 8,
                Name = "Dell Inspiron 3530 Core i3",
                UnitPrice = 60
            },
            new Product
            {
                ProductId = 9,
                Name = "Dell Vostro 5620 Core i5",
                UnitPrice = 70
            }
         

            );
        }
    }
}
