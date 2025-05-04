using DeveloperEvaluation.Core.Domain;

namespace E_Commerce.ProductsApi.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = default!;

        public string? Image { get; set; }

        public string Description { get; set; } = default!;

        public decimal Price { get; set; }
    }
}
