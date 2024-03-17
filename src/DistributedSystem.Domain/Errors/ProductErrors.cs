using DistributedSystem.Contract.Abstractions.Shared;
using MassTransit.SagaStateMachine;

namespace DistributedSystem.Domain.Errors
{
    public static class ProductErrors
    {
        public static Error NotFound(Guid productId) =>
            new Error("Products.NotFound", $"The product with the Id = '{productId}' was not found.");
    }
}