using E_Commerce.CartsApi.Models;
using E_Commerce.Core.Data;
using E_Commerce.MessageBus.Interface;
using E_Commerce.MessageBus.Models.Integration;
using E_Commerce.ProductsApi.Application.CreateProducts;
using E_Commerce.ProductsApi.Application.DeleteProducts;
using E_Commerce.ProductsApi.Application.UpdateProducts;
using Mapster;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace E_Commerce.ProductsApi.Application
{
    public class ProductsHandler :
        IRequestHandler<CreateProductsCommand, CreateProductsResult>,
        IRequestHandler<UpdateProductsCommand, UpdateProductsResult>,
        IRequestHandler<DeleteProductsCommand, DeleteProductsResult>
    {
        readonly IBaseRepository<Products> _productsRepository;
        readonly IMediator _mediator;
        readonly IMessageBusRabbitMq _messageBusRabbitMq;

        public ProductsHandler(IMessageBusRabbitMq messageBusRabbitMq,
            IMediator mediator, 
            IBaseRepository<Products> productsRepository)
        {
            _productsRepository = productsRepository;
            _mediator = mediator;
            _messageBusRabbitMq = messageBusRabbitMq;   
        }

        public async Task<CreateProductsResult> Handle(CreateProductsCommand request,
        CancellationToken cancellationToken)
        {

            var productTitle = await _productsRepository.RepositoryConsult.SearchAsync(x => x.Name == request.Name, cancellationToken);
            if (productTitle != null && productTitle.Any())
                throw new InvalidOperationException($"Produto com o nome {request.Name} já existe");


            var productAdd = request.Adapt<Products>();
            await _productsRepository.AddAsync(productAdd);
            await _productsRepository.UnitOfWork.CommitAsync();

            var insertProductsIntegrationEvent = productAdd.Adapt<InsertProductsIntegrationEvent>();

            await _mediator.Publish(insertProductsIntegrationEvent);

            var result = productAdd.Adapt<CreateProductsResult>();
            return result;
        }

        public async Task<UpdateProductsResult> Handle(UpdateProductsCommand request,
            CancellationToken cancellationToken)
        {

            var productTitle = await _productsRepository.RepositoryConsult.SearchAsync(x => x.Name == request.Name && x.Id != request.Id, cancellationToken);
            if (productTitle != null && productTitle.Any())
                throw new InvalidOperationException($"Produto com o nome {request.Name} já existe");


            var product = (await _productsRepository.RepositoryConsult.SearchAsync(x => x.Id == command.Id, cancellationToken))?.FirstOrDefault();
            if (product == null)
                throw new InvalidOperationException($"Produto não encontrado!");

            product.Description = request.Description;
            product.Price = request.Price ?? 0;
            product.Title = request.Name;
            product.Image = request.Image;
          
            await _productsRepository.UnitOfWork.CommitAsync();

            var UpdateProductsIntegrationEvent = product.Adapt<UpdateProductsIntegrationEvent>();

            await _mediator.Publish(UpdateProductsIntegrationEvent);
            var result = product.Adapt<UpdateProductsResult>();
            return result;
            
        }

        public async Task<DeleteProductsResult> Handle(DeleteProductsCommand request, 
            CancellationToken cancellationToken)
        {
            var product = (await _productsRepository.RepositoryConsult.SearchAsync(x => x.Id == request.Id))?.FirstOrDefault();
            if (product == null)
                throw new KeyNotFoundException($"Produto  ID {request.Id} não encontrado");

            _productsRepository.Remove(product);
            await _productsRepository.UnitOfWork.CommitAsync();

            var integration = product.Adapt<DeleteProductsIntegrationEvent>();
            await _mediator.Publish(integration);
            return new DeleteProductsResult {  };
        }
    }
}
