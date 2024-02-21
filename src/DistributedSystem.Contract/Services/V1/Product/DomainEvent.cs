using DistributedSystem.Contract.Abstractions.Message;

namespace DistributedSystem.Contract.Services.V1.Product
{
    public static class DomainEvent
    {
        public record ProductCreatedEvent(Guid IdEvent, Guid Id, string Name, decimal Price, string Description) : IDomainEvent;

        public record ProductDeleteEvent(Guid IdEvent, Guid Id) : IDomainEvent;

        public record ProductUpdatedEvent(Guid IdEvent, Guid Id, string Name, decimal Price, string Description) : IDomainEvent;
    }
}