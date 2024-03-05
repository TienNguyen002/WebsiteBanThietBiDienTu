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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired();

            builder.Property(c => c.UrlSlug)
                .IsRequired();

            builder.Property(c => c.Email)
                .IsRequired();

            builder.Property(c => c.Phone)
                .IsRequired();

            builder.Property(c => c.Address)
                .IsRequired();

            builder.Property(c => c.Password)
                .IsRequired()
                .HasMaxLength(16);

            builder.HasOne(r => r.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(r => r.RoleId)
                .HasConstraintName("FK_Roles_Users")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
