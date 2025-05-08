using DeveloperEvaluation.MessageBus.Models;
using E_Commerce.MessageBus.Interface;
using E_Commerce.MessageBus.Models.Integration;
using MediatR;

namespace E_Commerce.ProductsApi.Application
{
    public class ProductsEventHandler : 
        INotificationHandler<InsertProductsIntegrationEvent>,
        INotificationHandler<UpdateProductsIntegrationEvent>,
        INotificationHandler<DeleteProductsIntegrationEvent>
    {
        readonly IMessageBusRabbitMq _messageBusRabbitMq;
        public ProductsEventHandler(IMessageBusRabbitMq messageBusRabbitMq)
        {
            _messageBusRabbitMq = messageBusRabbitMq;
        }

        public async Task Handle(InsertProductsIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                _messageBusRabbitMq.Publish(notification,
                new PropsMessageQueeDto
                {
                    Queue = "QueeProductsInsert"
                });
            });

        }

        public async Task Handle(UpdateProductsIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                _messageBusRabbitMq.Publish(notification,
                new PropsMessageQueeDto
                {
                    Queue = "QueeProductsUpdate"
                });
            });
        }

        public async Task Handle(DeleteProductsIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                _messageBusRabbitMq.Publish(notification,
                new PropsMessageQueeDto
                {
                    Queue = "QueeProductsDeleted"
                });
            });

        }
    }
}
