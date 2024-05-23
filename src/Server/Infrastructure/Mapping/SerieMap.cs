using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class SerieMap : IEntityTypeConfiguration<Serie>
    {
        public void Configure(EntityTypeBuilder<Serie> builder)
        {
            builder.ToTable("Series");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired();

            builder.Property(s => s.UrlSlug)
                .IsRequired();

            builder.Property(p => p.Rating)
                .HasColumnType("float");

            builder.Property(s => s.Description)
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Series)
                .HasForeignKey(p => p.CategoryId)
                .HasConstraintName("FK_Categories_Series")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Branch)
                .WithMany(b => b.Series)
                .HasForeignKey(p => p.BranchId)
                .HasConstraintName("FK_Branches_Series")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
