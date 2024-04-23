using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.Property(c => c.Detail)
                .IsRequired();

            builder.Property(c => c.Rating)
               .IsRequired();

            builder.Property(c => c.CommentDate)
                .HasColumnType("datetime");

            builder.Property(c => c.Status)
                .HasDefaultValue(false);

            builder.HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .HasConstraintName("FK_Comments_Users")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Serie)
                .WithMany(s => s.Comments)
                .HasForeignKey(c => c.SerieId)
                .HasConstraintName("FK_Comments_Series")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
