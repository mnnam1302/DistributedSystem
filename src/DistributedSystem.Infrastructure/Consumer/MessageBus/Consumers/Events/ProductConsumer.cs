using DistributedSystem.Contract.Services.V1.Product;
using DistributedSystem.Infrastructure.Consumer.Abstractions.Messages;
using DistributedSystem.Infrastructure.Consumer.Abstractions.Repositories;
using DistributedSystem.Infrastructure.Consumer.Models;
using MediatR;

namespace DistributedSystem.Infrastructure.Consumer.MessageBus.Consumers.Events;

public static class ProductConsumer
{
    public class ProductCreatedConsumer : Consumer<DomainEvent.ProductCreatedDomainEvent>
    {
        public ProductCreatedConsumer(ISender sender, IMongoRepository<EventProjection> eventRepository) : base(sender, eventRepository)
        {
        }
    }

    public class ProductUpdatedConsumer : Consumer<DomainEvent.ProductUpdatedDomainEvent>
    {
        public ProductUpdatedConsumer(ISender sender, IMongoRepository<EventProjection> eventRepository) : base(sender, eventRepository)
        {
        }
    }

    public class ProductDeletedConsumer : Consumer<DomainEvent.ProductDeletedDomainEvent>
    {
        public ProductDeletedConsumer(ISender sender, IMongoRepository<EventProjection> eventRepository) : base(sender, eventRepository)
        {
        }
    }
}
