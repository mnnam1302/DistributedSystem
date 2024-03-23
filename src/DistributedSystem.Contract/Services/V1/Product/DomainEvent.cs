using DistributedSystem.Contract.Abstractions.Message;

namespace DistributedSystem.Contract.Services.V1.Product;

public static class DomainEvent
{
    // Kế thừa từ interface cha IDomainEvent
    // Tất cả class mà kế thừa từ INTERFACE IDomainEvent đều có thể add vào List<IDomainEvent> trong class AggregateRoot
    // => Tính chất đa hình
    // => Điểm hay của việc kế thừa từ interface
    public sealed record ProductCreatedDomainEvent(Guid IdEvent, Guid Id, string Name, decimal Price, string Description) : IDomainEvent, ICommand;

    public sealed record ProductDeletedDomainEvent(Guid IdEvent, Guid Id) : IDomainEvent, ICommand;

    public sealed record ProductUpdatedDomainEvent(Guid IdEvent, Guid Id, string Name, decimal Price, string Description) : IDomainEvent, ICommand;
}
