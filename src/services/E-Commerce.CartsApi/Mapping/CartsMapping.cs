using E_Commerce.CartsApi.Models;
using E_Commerce.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.CartsApi.Mapping
{
    public class CartsMapping : BaseMapping<Carts>
    {
        public override void Configure(EntityTypeBuilder<Carts> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.StatusCartsEn)
                .HasColumnName("StatusCartsEn")
                .IsRequired();

            builder.Property(x => x.DateOfSale)
                .HasColumnName("DateOfSale")
                .IsRequired(false);

            builder.ToTable("Carts");
        }
    }
}
