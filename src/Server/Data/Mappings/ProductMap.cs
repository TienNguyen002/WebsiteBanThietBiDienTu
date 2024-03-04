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

            builder.Property(p => p.Status)
                .HasDefaultValue(true);

            builder.Property(p => p.Price);

            builder.Property(p => p.OrPrice)
                .IsRequired();
            
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
        }
    }
}
