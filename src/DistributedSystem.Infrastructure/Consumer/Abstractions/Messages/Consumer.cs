using MassTransit;
using MediatR;

namespace DistributedSystem.Infrastructure.Consumer.Abstractions.Messages
{
    public abstract class Consumer<TMessage> : IConsumer<TMessage>
        where TMessage : class, Contract.Abstractions.Message.IDomainEvent
    {
        private readonly ISender Sender;

        protected Consumer(ISender sender)
        {
            Sender = sender;
        }

        public async Task Consume(ConsumeContext<TMessage> context)
        {
            await Sender.Send(context.Message); // Dont call _dbContext.SaveChangesAsync() hereS
        }
    }
}