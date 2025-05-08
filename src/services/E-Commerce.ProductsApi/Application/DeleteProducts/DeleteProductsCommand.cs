using MediatR;

namespace E_Commerce.ProductsApi.Application.DeleteProducts
{
    public class DeleteProductsCommand:IRequest<DeleteProductsResult>
    {
        public long Id { get; set; }
    }
}
