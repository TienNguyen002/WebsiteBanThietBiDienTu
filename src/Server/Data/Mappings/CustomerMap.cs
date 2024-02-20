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
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired();

            builder.Property(c => c.UrlSlug)
                .IsRequired();

            builder.Property(c => c.Email)
                .IsRequired();

            builder.Property(c => c.Phone)
                .IsRequired();

            builder.Property(c => c.Password)
                .IsRequired()
                .HasMaxLength(16);
        }
    }
}
