using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class DiscountMap : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.ToTable("Discounts");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.CodeName)
                .IsRequired();

            builder.Property(d => d.DiscountPercent)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); ;

            builder.Property(d => d.StartDate)
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now);

            builder.Property(d => d.EndDate)
                .HasColumnType("datetime");

            builder.Property(d => d.Status)
                .HasDefaultValue(true);
        }
    }
}
