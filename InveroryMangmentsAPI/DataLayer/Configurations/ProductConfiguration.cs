using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(x => x.ProductId);
            builder.HasIndex(x => x.ProductName).IsUnique();
            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(70);
            builder.Property(x => x.PurchasePrice).IsRequired().HasPrecision(18, 2);
            builder.Property(x=>x.SalePrice).IsRequired().HasPrecision(18, 2);
            builder.HasOne(x=>x.Category).WithMany(x=>x.Products).HasForeignKey(x=>x.CategoryId);
        }
    }
}
