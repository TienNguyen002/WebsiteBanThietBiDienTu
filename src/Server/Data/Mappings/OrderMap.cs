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
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.CustomerName)
                .IsRequired();

            builder.Property(o => o.Address)
                .IsRequired();

            builder.Property(o => o.Phone)
                .IsRequired();

            builder.Property(o => o.Email)
                .IsRequired();

            builder.Property(o => o.DateOrder)
                .HasColumnType("datetime");

            builder.Property(o => o.Quantity);

            builder.Property(o => o.TotalPrice);

            builder.HasOne(s => s.Status)
                .WithMany(o => o.Orders)
                .HasForeignKey(s => s.StatusId)
                .HasConstraintName("FK_Status_Orders")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
