using E_Commerce.ProductsApi.Application.CreateProducts;
using MediatR;

namespace E_Commerce.ProductsApi.Application.UpdateProducts
{
    public class UpdateProductsCommand: CreateProductsCommand, IRequest<UpdateProductsResult>
    {
        public long Id { get; set; }
    }
}
