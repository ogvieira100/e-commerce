using E_Commerce.Core.Data;
using E_Commerce.UsersApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.UsersApi.Mapping
{
    public class FunctionalityxProfileMapping : BaseMapping<FunctionalityxProfile>
    {

        public override void Configure(EntityTypeBuilder<FunctionalityxProfile> builder)
        {
            base.Configure(builder);

            builder.HasOne(x=>x.Functionality)
                .WithMany(x => x.FunctionalityxProfile)
                .HasForeignKey(x => x.FunctionalityId)
                .IsRequired(true);

            builder.HasOne(x => x.Profile)
               .WithMany(x => x.FunctionalityxProfile)
               .HasForeignKey(x => x.ProfileId)
               .IsRequired(true);

            builder.ToTable("FunctionalityxProfile");
        }

    }
}
