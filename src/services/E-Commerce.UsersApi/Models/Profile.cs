using DeveloperEvaluation.Core.Domain;
using E_Commerce.UsersApi.Mapping;

namespace E_Commerce.UsersApi.Models
{
    public class Profile : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public virtual IEnumerable<FunctionalityxProfile> FunctionalityxProfile { get; set; }
        public virtual IEnumerable<ProfilexUsers> ProfilexUsers { get; set; }

        public Profile()
        {
            FunctionalityxProfile = new List<FunctionalityxProfile>();
            ProfilexUsers = new List<ProfilexUsers>();    
        }

    }
}
