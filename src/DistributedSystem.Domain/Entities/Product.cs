using DistributedSystem.Domain.Abstractions.Aggregates;
using DistributedSystem.Domain.Abstractions.Entities;
using System.Diagnostics.Contracts;

namespace DistributedSystem.Domain.Entities
{
    public class Product : AggregateRoot<Guid>, IAuditableEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedOnUtc { get; set; }
        public DateTimeOffset? ModifiedOnUtc { get; set; }

        // Thằng này mới nên chưa có instance nào reference đến Create, ví dụ, instance.Create(...) => Không có => có static
        public static Product Create(Guid id, string name, decimal price, string description)
        {
            var product = new Product(id, name, price, description);

            // Khi Raise event , thì sẽ add class ProductCreated vào trong List
            product.RaiseDomainEvent(new Contract.Services.V1.Product.DomainEvent.ProductCreated(Guid.NewGuid(), product.Id,
                product.Name, product.Price, 
                product.Description
                ));

            return product;
        }

        public Product(Guid id, string name, decimal price, string description)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
        }

        // Có instance hay đối tượng reference đến Update, ví dụ, instance.Update(...) 
        // Phải tham chiếu từ một đối tượng cụ thể
        public void Update(string name, decimal price, string description)
        {
            Name = name;
            Price = price;
            Description = description;

            RaiseDomainEvent(new Contract.Services.V1.Product.DomainEvent.ProductUpdated(Guid.NewGuid(), Id, Name, Price, Description));
        }

        // Có instance hay đối tượng reference đến Update, ví dụ, instance.Update(...)
        public void Delete()
            => RaiseDomainEvent(new Contract.Services.V1.Product.DomainEvent.ProductDeleted(Guid.NewGuid(), Id));
    }
}