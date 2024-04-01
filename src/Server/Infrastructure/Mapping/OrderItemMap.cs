using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Quantity)
                .IsRequired();

            builder.Property(o => o.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); ;

            builder.HasOne(o => o.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(o => o.OrderId)
                .HasConstraintName("FK_OrderItems_Orders")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(o => o.ProductId)
                .HasConstraintName("FK_OrderItems_Products")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
