using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Context.Confiqurations
{
    internal class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
               .HasColumnType("VarChar")
               .HasMaxLength(256);
            builder.Property(p => p.PictureUrl)
               .HasColumnType("VarChar")
               .HasMaxLength(256);
            builder.Property(p => p.Description)
               .HasColumnType("VarChar")
               .HasMaxLength(512);
            builder.Property(p => p.Price)
               .HasColumnType("decimal(10,2)")
               .HasMaxLength(256);

            builder.HasOne(p=> p.ProductType)
                .WithMany()
                .HasForeignKey(p => p.TypeId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p=> p.ProductBrand)
                .WithMany()
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    
    }
}
