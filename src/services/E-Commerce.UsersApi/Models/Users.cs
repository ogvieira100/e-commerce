using DeveloperEvaluation.Core.Domain;
using E_Commerce.UsersApi.Mapping;

namespace E_Commerce.UsersApi.Models
{
    public class Users : BaseEntity
    {
        public string CPF { get; set; } = default!; 

        public string Name { get; set; }  = default!;

        public string UserName { get; set; }  = default!;

        public string Password { get; set; } = default!;

        public string Email { get; set; } = default!;

        public virtual IEnumerable<ProfilexUsers> ProfilexUsers { get; set; }

        public Users()
        {
            ProfilexUsers = new List<ProfilexUsers>();    
        }

    }
}
