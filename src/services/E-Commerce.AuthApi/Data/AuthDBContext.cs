using E_Commerce.Core.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace E_Commerce.AuthApi.Data
{

    public class ApplicationRole : IdentityRole<long>
    {
    }
    public class ApplicationUser : IdentityUser<long>
    {
        
    }
    public class AuthDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>, IDbContext
    {
        public IDbConnection Connection
        => this.Database.GetDbConnection();
        public AuthDBContext(DbContextOptions<AuthDBContext> options) : base(options) { }

    }
}
