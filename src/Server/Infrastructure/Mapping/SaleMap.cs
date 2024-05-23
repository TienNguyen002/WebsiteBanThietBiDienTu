using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class SaleMap : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(p => p.Id);

            builder.Property(d => d.EndDate)
                .HasColumnType("datetime")
                .IsRequired(false);

            builder.Property(p => p.Status)
                .HasDefaultValue(true);
        }
    }
}
