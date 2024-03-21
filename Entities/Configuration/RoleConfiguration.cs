using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Name = "Consumer",
                NormalizedName = "CONSUMER"
            },
            new IdentityRole
            {
                Name = "Vendor",
                NormalizedName = "VENDOR"
            },

            new IdentityRole
            {
                Name = "Distributor",
                NormalizedName = "DISTRIBUTOR"
            }

            );
        }
    }
}
