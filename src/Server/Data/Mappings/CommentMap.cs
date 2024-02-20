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
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.Property(c => c.Detail)
                .IsRequired();

            builder.Property(c => c.CreatedDate)
                .HasColumnType("datetime");

            builder.HasOne(c => c.Customer)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.CustomerId)
                .HasConstraintName("FK_Comments_Customers")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Product)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.ProductId)
                .HasConstraintName("FK_Comments_Products")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
