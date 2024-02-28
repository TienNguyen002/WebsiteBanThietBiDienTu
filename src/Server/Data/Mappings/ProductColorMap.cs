﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class ProductColorMap : IEntityTypeConfiguration<ProductColor>
    {
        public void Configure(EntityTypeBuilder<ProductColor> builder)
        {
            builder.ToTable("ProductColors");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Color)
                .IsRequired();

            builder.Property(p => p.UrlSlug)
                .IsRequired();
        }
    }
}