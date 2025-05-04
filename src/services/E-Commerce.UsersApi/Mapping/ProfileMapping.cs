using E_Commerce.Core.Data;
using E_Commerce.UsersApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.UsersApi.Mapping
{
    public class ProfileMapping : BaseMapping<Profile>
    {
        public override void Configure(EntityTypeBuilder<Profile> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired();


            builder.Property(x => x.Description)
             .HasColumnName("Description")
             .HasMaxLength(2000)
             .IsRequired();


            builder.ToTable("Profile");
        }

    }
}
