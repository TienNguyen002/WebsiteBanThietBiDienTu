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
    public class TrademarkMap : IEntityTypeConfiguration<Trademark>
    {
        public void Configure(EntityTypeBuilder<Trademark> builder)
        {
            builder.ToTable("Trademarks");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired();

            builder.Property(t => t.UrlSlug)
                .IsRequired();

            builder.HasMany(c => c.Categories)
                .WithMany(t => t.Trademarks)
                .UsingEntity(ct => ct.ToTable("CategoriesTrademarks"));
        }
    }
}
