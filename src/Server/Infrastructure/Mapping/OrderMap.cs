using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Name);

            builder.Property(o => o.Address);

            builder.Property(o => o.Phone);

            builder.Property(o => o.DateOrder)
                .HasColumnType("datetime");

            builder.Property(o => o.Quantity);

            builder.Property(o => o.TotalPrice);

            builder.HasOne(o => o.Status)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.StatusId)
                .HasConstraintName("FK_Statuses_Orders")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.ApplicationUser)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.ApplicationUserId)
                .HasConstraintName("FK_Users_Orders")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.PaymentMethod)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.PaymentMethodId)
                .HasConstraintName("FK_Orders_PaymentMethods")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.Discount)
               .WithMany(d => d.Orders)
               .HasForeignKey(o => o.DiscountId)
               .HasConstraintName("FK_Orders_Discounts")
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
