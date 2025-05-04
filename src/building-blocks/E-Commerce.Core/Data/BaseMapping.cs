using DeveloperEvaluation.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Data
{
    public abstract class BaseMapping<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(u => u.DateCreated)
                   .HasColumnName("DateCreated")
                   .IsRequired();

            builder.Property(u => u.IdUserInserted)
                   .HasColumnName("IdUserInserted")
                   .IsRequired();

            builder.Property(u => u.Active)
                   .HasColumnName("Active")
                   .IsRequired();


            builder.Property(u => u.IdUserUpdated)
                    .HasColumnName("IdUserUpdated")
                    .IsRequired(false);

            builder.Property(u => u.DateUpdated)
                    .HasColumnName("DateUpdated")
                    .IsRequired(false);

            builder.Property(u => u.IdUserDeleted)
                  .HasColumnName("IdUserDeleted")
                  .IsRequired(false);

            builder.Property(u => u.DateDeleted)
                    .HasColumnName("DateDeleted")
                    .IsRequired(false);

        }
    }
}
