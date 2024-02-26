using DistributedSystem.Contract.Abstractions.Message;
using DistributedSystem.Contract.Abstractions.Shared;
using DistributedSystem.Contract.Services.V1.Product;
using MassTransit.Util.Scanning;

namespace DistributedSystem.Infrastructure.Consumer.UseCases.Events
{
    // Kiểu Centralized cực kỳ hay
    internal class ProjectProductDetailsWhenProductChangeEventHandler
        : ICommandHandler<DomainEvent.ProductCreated>,
        ICommandHandler<DomainEvent.ProductUpdated>,
        ICommandHandler<DomainEvent.ProductDeleted>
    {
        // Repository working MongoDB
        public async Task<Result> Handle(DomainEvent.ProductCreated request, CancellationToken cancellationToken)
        {
            // Create a new Product
            await Task.Delay(1000);

            return Result.Success();
        }

        public async Task<Result> Handle(DomainEvent.ProductUpdated request, CancellationToken cancellationToken)
        {
            // Find and update a Product
            await Task.Delay(1000);

            return Result.Success();
        }

        public async Task<Result> Handle(DomainEvent.ProductDeleted request, CancellationToken cancellationToken)
        {
            // Find and delete a Product
            await Task.Delay(1000);

            return Result.Success();
        }
    }
}