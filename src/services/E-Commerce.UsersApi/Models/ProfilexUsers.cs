using DeveloperEvaluation.Core.Domain;

namespace E_Commerce.UsersApi.Models
{
    public class ProfilexUsers : BaseEntity
    {
        public long ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
        public long UsersId { get; set; }
        public virtual Users Users { get; set; }
    }
}
