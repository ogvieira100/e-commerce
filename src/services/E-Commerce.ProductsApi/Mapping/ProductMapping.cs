using E_Commerce.Core.Data;
using E_Commerce.ProductsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.ProductsApi.Mapping
{
    public class ProductMapping: BaseMapping<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.Image)
                .HasColumnName("Image")
                .IsRequired(false)
                .HasMaxLength(200);

            builder.Property(u => u.Description)
                .HasColumnName("Description")
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(u => u.Price)
                .HasColumnName("Price")
                .IsRequired()
                .HasPrecision(20, 10);

            builder.ToTable("Products");
        }
    }
}
