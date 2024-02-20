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
    public class SpecificationCategoryMap : IEntityTypeConfiguration<SpecificationCategory>
    {
        public void Configure(EntityTypeBuilder<SpecificationCategory> builder)
        {
            builder.ToTable("SpecificationCategories");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired();

            builder.Property(s => s.UrlSlug)
                .IsRequired();
        }
    }
}
