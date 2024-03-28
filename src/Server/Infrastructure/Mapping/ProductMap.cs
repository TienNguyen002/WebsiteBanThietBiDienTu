using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired();

            builder.Property(p => p.UrlSlug)
                .IsRequired();

            builder.Property(p => p.Description) 
                .IsRequired();

            builder.Property(p => p.Specification)
                .IsRequired();

            builder.Property(p => p.ImageUrl)
                .HasMaxLength(1000);

            builder.Property(p => p.Amount)
                .HasMaxLength(500);

            builder.Property(p => p.Status)
                .HasDefaultValue(true);

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.OrPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .HasConstraintName("FK_Categories_Products")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Branch)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BranchId)
                .HasConstraintName("FK_Branches_Products")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Tag)
                .WithMany(t => t.Products)
                .HasForeignKey(p => p.TagId)
                .HasConstraintName("FK_Tags_Products")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Colors)
                .WithMany(c => c.Products)
                .UsingEntity(sp => sp.ToTable("ProductColors"));
        }
    }
}
