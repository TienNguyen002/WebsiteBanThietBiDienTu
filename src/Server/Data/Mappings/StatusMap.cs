using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class StatusMap : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Status");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired();

            builder.Property(s => s.UrlSlug)
                .IsRequired();
        }
    }
}
