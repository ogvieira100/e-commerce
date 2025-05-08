using DeveloperEvaluation.Core.Domain;

namespace E_Commerce.ProductsApi.Models.Request
{
    public class GetPaginatedProductsRequest : PagedDataRequest
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
    }
}
