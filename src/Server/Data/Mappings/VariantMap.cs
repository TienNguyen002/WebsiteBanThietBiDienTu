using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class VariantMap : IEntityTypeConfiguration<Variant>
    {
        public void Configure(EntityTypeBuilder<Variant> builder)
        {
            builder.ToTable("Variants");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired();

            builder.Property(p => p.UrlSlug)
                .IsRequired();

            builder.Property(p => p.Amount)
                .HasMaxLength(500);

            builder.Property(p => p.Status)
                .HasDefaultValue(true);

            builder.Property(p => p.Price);

            builder.Property(p => p.OrPrice)
                .IsRequired();

            builder.HasOne(p => p.Product)
                .WithMany(p => p.Variants)
                .HasForeignKey(t => t.ProductId)
                .HasConstraintName("FK_Products_Variants")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Specifications)
                .WithMany(p => p.Variants)
                .UsingEntity(sp => sp.ToTable("VariantSpecifications"));

            builder.HasMany(c => c.Colors)
                .WithMany(p => p.Variants)
                .UsingEntity(sp => sp.ToTable("VariantColors"));

            builder.HasMany(c => c.Carts)
                .WithMany(p => p.Variants)
                .UsingEntity(sp => sp.ToTable("VariantOrders"));
        }
    }
}
