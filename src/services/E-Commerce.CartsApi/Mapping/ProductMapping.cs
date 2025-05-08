using E_Commerce.CartsApi.Models;
using E_Commerce.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.CartsApi.Mapping
{
    public class ProductMapping : BaseMapping<Products>
    {
        public override void Configure(EntityTypeBuilder<Products> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.ProductIdIntegrated)
              .HasColumnName("ProductIdIntegrated")
              .IsRequired();

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

            builder.ToTable("ProductsxCarts");
        }
    }
}
