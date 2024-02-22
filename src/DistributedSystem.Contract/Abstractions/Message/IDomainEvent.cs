using MediatR;

namespace DistributedSystem.Contract.Abstractions.Message
{
    public interface IDomainEvent : INotification
    {
        public Guid IdEvent { get; init; }
    }
}