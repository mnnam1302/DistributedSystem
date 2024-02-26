using DistributedSystem.Persistence;
using MassTransit;
using Quartz;

namespace DistributedSystem.Infrastructure.BackgroundJobs
{
    public class ProducerOutboxMessageJob : IJob
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IPublishEndpoint _publishEndpoint; // Maybe can use Rebus library

        public ProducerOutboxMessageJob(ApplicationDbContext dbContext, IPublishEndpoint publishEndpoint)
        {
            _dbContext = dbContext;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            // Fetching data in the OutboxMesssage table and send into RabbitMQ

        }
    }
}