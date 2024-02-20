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
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Images");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.ImageUrl)
                .HasMaxLength(1000);

            builder.HasOne(p => p.Product)
                .WithMany(i => i.Images)
                .HasForeignKey(p => p.ProductId)
                .HasConstraintName("FK_Images_Products")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
