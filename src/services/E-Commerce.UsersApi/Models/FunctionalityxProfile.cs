using DeveloperEvaluation.Core.Domain;

namespace E_Commerce.UsersApi.Models
{
    public class FunctionalityxProfile : BaseEntity
    {
        public long FunctionalityId { get; set; }
        public virtual Functionality Functionality { get; set; }
        public long ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

    }
}
