using DistributedSystem.Domain.Abstractions.Aggregates;
using DistributedSystem.Domain.Abstractions.Entities;

namespace DistributedSystem.Domain.Entities
{
    public class Product : AggregateRoot<Guid>, IAuditableEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedOnUtc { get; set; }
        public DateTimeOffset? ModifiedOnUtc { get; set; }

        public static Product Create(Guid id, string name, decimal price, string description)
        {
            var product = new Product(id, name, price, description);

            //product.RaiseDomainEvent(new )

            return product;
        }

        public Product(Guid id, string name, decimal price, string description)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
        }
    }
}