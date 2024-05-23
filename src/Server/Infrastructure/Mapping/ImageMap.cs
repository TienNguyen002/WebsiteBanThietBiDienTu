using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Images");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.ImageUrl)
                .HasMaxLength(1000);

            builder.HasOne(i => i.Serie)
                .WithMany(s => s.Images)
                .HasForeignKey(i => i.SerieId)
                .HasConstraintName("FK_Images_Series")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
