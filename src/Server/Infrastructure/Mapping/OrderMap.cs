using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.DateOrder)
                .HasColumnType("datetime");

            builder.Property(o => o.Quantity);

            builder.Property(o => o.TotalPrice)
                .HasColumnType("decimal(18,2)"); ;

            builder.HasOne(o => o.Status)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.StatusId)
                .HasConstraintName("FK_Statuses_Orders")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .HasConstraintName("FK_Users_Orders")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.PaymentMethod)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.PaymentMethodId)
                .HasConstraintName("FK_Orders_PaymentMethods")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
