using E_Commerce.Core.Data;
using E_Commerce.ProductsApi.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace E_Commerce.ProductsApi.Data.Context
{
    public class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
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
