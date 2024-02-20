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
    public class SpecificationMap : IEntityTypeConfiguration<Specification>
    {
        public void Configure(EntityTypeBuilder<Specification> builder)
        {
            builder.ToTable("Specifications");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Details)
                .IsRequired();

            builder.HasOne(s => s.SpecificationCategory)
                .WithMany(s => s.Specifications)
                .HasForeignKey(s => s.SpecificationCategoryId)
                .HasConstraintName("FK_Categories_Specifications")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
