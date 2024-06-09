using Entities.Models;
using Entities.Models.OrderTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(

               new Customer
               {
                   CustomerId = 1,
                   Name = "Elon Musk",
                   Address = "583 Wall Dr. Gwynn Oak, MD 21207",
               },

               new Customer
               {
                   CustomerId = 2,
                   Name = "Bill Gates",
                   Address = "312 Forest Avenue, BF 923",

               },

                new Customer
                {
                    CustomerId = 3,
                    Name = "Jeff Bejos",
                    Address = "345 Street Forest Avenue, BF 923",

                }

                   ); 
        }
    }
}
