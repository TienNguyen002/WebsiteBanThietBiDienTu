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
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired();

            builder.Property(p => p.UrlSlug)
                .IsRequired();

            builder.Property(p => p.Description) 
                .IsRequired();

            builder.Property(p => p.ImageUrl)
                .HasMaxLength(1000);

            builder.Property(p => p.Tag)
                .IsRequired();

            builder.Property(p => p.Amount)
                .HasMaxLength(500);

            builder.Property(p => p.Status)
                .HasDefaultValue(true);

            builder.Property(p => p.Price);

            builder.Property(p => p.OrPrice)
                .IsRequired();

            builder.Property(p => p.AddAmount);
            
            builder.HasOne(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(c => c.CategoryId)
                .HasConstraintName("FK_Categories_Products")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Trademark)
                .WithMany(p => p.Products)
                .HasForeignKey(t => t.TrademarkId)
                .HasConstraintName("FK_Trademarks_Products")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Specifications)
                .WithMany(p => p.Products)
                .UsingEntity(sp => sp.ToTable("ProductSpecifications"));

            builder.HasOne(s => s.Staff)
                .WithMany(p => p.Products)
                .HasForeignKey(s => s.StaffId)
                .HasConstraintName("FK_Staffs_Products")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.Order)
                .WithMany(p => p.Products)
                .HasForeignKey(s => s.OrderId)
                .HasConstraintName("FK_Orders_Products")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
