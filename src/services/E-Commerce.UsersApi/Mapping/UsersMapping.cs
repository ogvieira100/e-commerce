using E_Commerce.Core.Data;
using E_Commerce.UsersApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.UsersApi.Mapping
{
   public class UsersMapping : BaseMapping<Users>
    {
        public override void Configure(EntityTypeBuilder<Users> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
              .HasColumnName("Name")
              .HasMaxLength(200)    
              .IsRequired();

            builder.Property(x => x.UserName)
            .HasColumnName("UserName")
            .HasMaxLength(200)
            .IsRequired();

            builder.Property(x => x.Password)
           .HasColumnName("Password")
           .HasMaxLength(200)
           .IsRequired();

            builder.Property(x => x.Email)
             .HasColumnName("Email")
             .HasMaxLength(200)
             .IsRequired();


            builder.Property(x => x.CPF)
             .HasColumnName("CPF")
             .HasMaxLength(20)
             .IsRequired();

           

            builder.ToTable("Users");
        }
    }
}
