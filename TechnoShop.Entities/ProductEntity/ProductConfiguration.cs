﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoShop.Entities.ProductEntity
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(q => q.ProductId);
            builder.Property(q => q.Name).HasMaxLength(150);
            builder.Property(q => q.Description).HasMaxLength(600);
            builder.Property(q => q.Cost).HasDefaultValue(0);
            builder.Property(q => q.Count).HasDefaultValue(1);
            builder.Property(q => q.ProductPage).UseIdentityColumn();

            //builder.HasOne(q => q.ProductType).WithMany(q => q.Products).HasForeignKey(q => q.ProductTypeName).HasPrincipalKey(q => q.TypeName);
        }
    }
}
