using E_Commerce.CartsApi.Models;
using E_Commerce.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.CartsApi.Mapping
{
    public class CartsItensMapping : BaseMapping<CartsItens>
    {
        public override void Configure(EntityTypeBuilder<CartsItens> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Quantity)
                .HasColumnName("Quantity")
                .IsRequired();

            builder.Property(x => x.Discounts)
                .HasPrecision(20, 5)
                .HasColumnName("Discounts")
                .IsRequired(false);

            builder.Property(x => x.UnitPrices)
               .HasPrecision(20, 5)
               .HasColumnName("UnitPrices")
               .IsRequired();

            builder.Property(x => x.DateAdd)
              .HasColumnName("DateAdd")
              .IsRequired();

            builder.Property(x => x.DateUpdated)
            .HasColumnName("DateUpdated")
            .IsRequired(false);


            /*relations One two many*/

            builder.HasOne(x => x.Carts)
                .WithMany(x => x.CartItens)
                .HasForeignKey(x => x.CartsId)
                .IsRequired(true);

            builder.HasOne(x => x.Product)
               .WithMany(x => x.CartsItens)
               .HasForeignKey(x => x.ProductId)
               .IsRequired(true);

            builder.ToTable("CartsItens");
        }
    }
}
