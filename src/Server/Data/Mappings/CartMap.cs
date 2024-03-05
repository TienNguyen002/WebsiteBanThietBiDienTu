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
    public class CartMap : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Status)
                .HasDefaultValue(false);

            builder.HasOne(c => c.User)
                .WithMany(c => c.Carts)
                .HasForeignKey(c => c.UserId)
                .HasConstraintName("FK_Users_Carts")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
