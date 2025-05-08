using E_Commerce.CartsApi.Models;
using E_Commerce.Core.Data;
using E_Commerce.Core.Web;
using E_Commerce.ProductsApi.Application.CreateProducts;
using E_Commerce.ProductsApi.Application.DeleteProducts;
using E_Commerce.ProductsApi.Application.Queries;
using E_Commerce.ProductsApi.Application.UpdateProducts;
using E_Commerce.ProductsApi.Models;
using E_Commerce.ProductsApi.Models.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.ProductsApi.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IMediator _mediator;
        readonly IProductsQueries _productsQueries;

        public ProductsController(IMediator mediator,
            IProductsQueries productsQueries)
        {
            _mediator = mediator;
            _productsQueries = productsQueries;
        }

        /// <summary>
        /// DeleteProduct
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("/{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            var command = new DeleteProductsCommand { Id = id };
            var resp = await _mediator.Send(command, cancellationToken);
            return Ok(resp);
        }



        /// <summary>
        /// GetProducts
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("All")]
        public async Task<IActionResult> GetAllProducts(CancellationToken cancellationToken = default)
        {
            var response = new List<Products>();
            return Ok(await _productsQueries.GetAllProductsAsync(cancellationToken));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="getPaginatedProductsRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet()]
        public async Task<IActionResult> GetProducts([FromQuery] GetPaginatedProductsRequest getPaginatedProductsRequest, CancellationToken cancellationToken = default)
        {
            return Ok(await _productsQueries.GetPaginatedProductsRequestAsync(getPaginatedProductsRequest, cancellationToken));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        [HttpGet("GetProduct/{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] long id, CancellationToken cancellationToken = default)
        {

            var response = await _productsQueries.GetByIdAsync(id, cancellationToken);
            if (response == null)
                throw new KeyNotFoundException($"Produto com  ID {id} não encontrado");

            return base.Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateProductsCommand"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateProducts([FromBody] UpdateProductsCommand  updateProductsCommand, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(updateProductsCommand, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createProductsCommand"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
       
        public async Task<IActionResult> CreateProducts([FromBody] CreateProductsCommand  createProductsCommand,
            CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(createProductsCommand, cancellationToken);
            return Created(string.Empty, response);
        }

    }
}
