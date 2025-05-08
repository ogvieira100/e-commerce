using DeveloperEvaluation.Core.Domain;
using E_Commerce.CartsApi.Models;
using E_Commerce.Core.Data;
using E_Commerce.ProductsApi.Models.Dto;
using E_Commerce.ProductsApi.Models.Request;
using Mapster;

namespace E_Commerce.ProductsApi.Application.Queries
{
    public interface IProductsQueries
    {
        Task<Products?> GetByIdAsync(long Id, CancellationToken cancellationToken = default);

        Task<IEnumerable<Products>> GetAllProductsAsync(CancellationToken cancellationToken = default);
        Task<PagedDataResponse<Products>> GetPaginatedProductsRequestAsync(GetPaginatedProductsRequest getPaginatedProductsRequest, CancellationToken cancellationToken = default);

    }

    public class ProductsQueries : IProductsQueries
    {

        readonly IBaseRepository<Products> _baseProductsRepository;
        
        public ProductsQueries(IBaseRepository<Products> baseProductsRepository)
        {
            _baseProductsRepository = baseProductsRepository;
        }

        public async Task<IEnumerable<Products>> GetAllProductsAsync(CancellationToken cancellationToken = default)
        {
            /*Dapper*/
            var query = @"
               SELECT 
		            ""Id"",
		            ""Name"",
		            ""Image"",
		            ""Description"",
		            ""Price"",
		            ""DateUpdated"",
		            ""IdUserUpdated"",
		            ""DateDeleted"",
		            ""IdUserDeleted"",
		            ""DateCreated"",
		            ""IdUserInserted"", 
		            ""Active""
	            FROM public.""Products"";
            ";
            var allProducts = await _baseProductsRepository.RepositoryConsult.SearchAsync<ProductsSearchDto>(query, cancellationToken);
            return allProducts.Select(x => x.Adapt<Products>());
        }

        public async Task<Products?> GetByIdAsync(long Id, CancellationToken cancellationToken = default)
                  => (await _baseProductsRepository.RepositoryConsult.SearchAsync(x => x.Id == Id, cancellationToken))?.FirstOrDefault();

        public async Task<PagedDataResponse<Products>> GetPaginatedProductsRequestAsync(GetPaginatedProductsRequest getPaginatedProductsRequest,
            CancellationToken cancellationToken = default)
        {
            var query = _baseProductsRepository.RepositoryConsult.GetQueryable();

            if (!string.IsNullOrEmpty(getPaginatedProductsRequest.Description))
                query = query.Where(x => x.Description.Contains(getPaginatedProductsRequest.Description));

            if (!string.IsNullOrEmpty(getPaginatedProductsRequest.Name))
                query = query.Where(x => x.Name.Contains(getPaginatedProductsRequest.Name));

          
           return await query.PaginateAsync(getPaginatedProductsRequest, cancellationToken);

        }
    }
}
