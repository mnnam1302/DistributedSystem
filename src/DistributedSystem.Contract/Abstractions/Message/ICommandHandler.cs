using MediatR;

namespace DistributedSystem.Contract.Abstractions.Message
{
    public interface ICommandHandler : INotification
    {
        public Guid IdEvent { get; init; }
    }
}