using E_Commerce.Core.Data;
using E_Commerce.UsersApi.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace E_Commerce.UsersApi.Data
{
    public class UserDBContext:DbContext, IDbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options)
            : base(options)
        {
        }
        public IDbConnection Connection
          => this.Database.GetDbConnection();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FunctionalityMapping());
            modelBuilder.ApplyConfiguration(new FunctionalityxProfileMapping());
            modelBuilder.ApplyConfiguration(new ProfileMapping());
            modelBuilder.ApplyConfiguration(new ProfilexUsersMapping());
            modelBuilder.ApplyConfiguration(new UsersMapping());
        }

    }
}
