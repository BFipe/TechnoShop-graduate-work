﻿        using Microsoft.EntityFrameworkCore;
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
            builder.Property(q => q.PictureLink).HasMaxLength(300);
            builder.Property(q => q.Cost).IsRequired(true);
            builder.Property(q => q.Count).IsRequired(true);
            builder.Property(q => q.InOrderCount).IsRequired(true);
        }
    }
}
