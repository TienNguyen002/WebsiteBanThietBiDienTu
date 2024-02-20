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
    public class ConfigurationMap : IEntityTypeConfiguration<Configuration>
    {
        public void Configure(EntityTypeBuilder<Configuration> builder)
        {
            builder.ToTable("Configurations");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired();

            builder.Property(c => c.UrlSlug) 
                .IsRequired();

            builder.Property(c => c.Price);

            builder.Property(c => c.OrPrice)
                .IsRequired();

            builder.HasOne(p => p.Product)
                .WithMany(c => c.Configurations)
                .HasForeignKey(p => p.ProductId)
                .HasConstraintName("FK_Products_Configurations")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
