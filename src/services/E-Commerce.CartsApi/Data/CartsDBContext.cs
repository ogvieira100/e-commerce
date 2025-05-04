using E_Commerce.CartsApi.Mapping;
using E_Commerce.Core.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace E_Commerce.CartsApi.Data
{
    public class CartsDBContext : DbContext, IDbContext
    {
        public CartsDBContext(DbContextOptions<CartsDBContext> options)
            : base(options)
        {
        }
        public IDbConnection Connection
          => this.Database.GetDbConnection();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
        }

    }
}
