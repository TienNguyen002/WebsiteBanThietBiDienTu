using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.Property(c => c.Detail)
                .IsRequired();

            builder.Property(c => c.CommentDate)
                .HasColumnType("datetime");

            builder.HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .HasConstraintName("FK_Comments_Users")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Product)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ProductId)
                .HasConstraintName("FK_Comments_Products")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
