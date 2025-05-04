using E_Commerce.Core.Data;
using E_Commerce.UsersApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.UsersApi.Mapping
{
    public class ProfilexUsersMapping : BaseMapping<ProfilexUsers>
    {

        public override void Configure(EntityTypeBuilder<ProfilexUsers> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Profile)
                .WithMany(x => x.ProfilexUsers)
                .HasForeignKey(x => x.ProfileId)
                .IsRequired(true);

            builder.HasOne(x => x.Users)
               .WithMany(x => x.ProfilexUsers)
               .HasForeignKey(x => x.UsersId)
               .IsRequired(true);
            builder.ToTable("ProfilexUsers");
        }

    }
}
