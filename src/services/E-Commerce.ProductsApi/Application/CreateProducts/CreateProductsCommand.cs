using MediatR;

namespace E_Commerce.ProductsApi.Application.CreateProducts
{
    public class CreateProductsCommand:IRequest<CreateProductsResult>
    {
        public string Name { get; set; } = default!;

        public string? Image { get; set; }

        public string Description { get; set; } = default!;

        public decimal? Price { get; set; }
    }
}
