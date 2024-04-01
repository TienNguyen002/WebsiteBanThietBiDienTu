using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping
{
    public class DiscountMap : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.ToTable("Discounts");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.DiscountPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); ;

            builder.Property(d => d.StartDate)
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now);

            builder.Property(d => d.EndDate)
                .HasColumnType("datetime");

            builder.Property(d => d.Status)
                .HasDefaultValue(true);

            builder.HasOne(d => d.Product)
                .WithMany(p => p.Discounts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Discounts_Products")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
