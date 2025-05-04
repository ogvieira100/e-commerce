using DeveloperEvaluation.Core.Domain;

namespace E_Commerce.UsersApi.Models
{
    public class Functionality : BaseEntity
    {
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public virtual IEnumerable<FunctionalityxProfile> FunctionalityxProfile { get; set; }

        public Functionality()
        {
            FunctionalityxProfile = new List<FunctionalityxProfile>();
        }

    }
}
