using DeveloperEvaluation.Core.Domain;

namespace E_Commerce.CartsApi.Models
{
    public class Products : BaseEntity
    {
        public long ProductIdIntegrated { get; set; }

        public string Name { get; set; } = default!;

        public string? Image { get; set; }

        public string Description { get; set; } = default!;

        public decimal Price { get; set; }

        public virtual IEnumerable<CartsItens> CartsItens { get; set; }

        public Products()
        {
            CartsItens = new List<CartsItens>();
        }
    }
}
