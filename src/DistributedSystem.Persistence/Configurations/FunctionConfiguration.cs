using Castle.DynamicProxy.Generators;
using DistributedSystem.Domain.Entities.Identity;
using DistributedSystem.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistributedSystem.Persistence.Configurations
{
    internal sealed class FunctionConfiguration : IEntityTypeConfiguration<Function>
    {
        public void Configure(EntityTypeBuilder<Function> builder)
        {
            builder.ToTable(TableNames.Functions);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasMaxLength(50);
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.ParentId).HasMaxLength(50).HasDefaultValue(null);
            builder.Property(x => x.CssClass).HasMaxLength(50).HasDefaultValue(null);
            builder.Property(x => x.ParentId).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.SortOrder).HasDefaultValue(null);

            // Each Function can have many Permissions
            builder.HasMany(e => e.Permissions)
                .WithOne()
                .HasForeignKey(x => x.FunctionId)
                .IsRequired();

            // Each Function can have many ActionInFunctions
            builder.HasMany(e => e.ActionInFunctions)
                .WithOne()
                .HasForeignKey(aif => aif.FunctionId)
                .IsRequired();


            var functions = new List<Function>()
            {
                new Function()
                {
                    Id = "1b8c6511-d1db-4c01-b65a-1c60ec0bf90c",
                    Name = "Retrieve all products",
                    Url = "http://localhost:5000/api/v1/products",
                    ParentId = "13e2f21a-4283-4ff8-bb7a-096e7b89e0f0",
                    SortOrder = 2,
                    CssClass = "ProductApi"
                },
                new Function()
                {
                    Id = "401b7a1d-6489-4b0e-9dc7-a27277d6e3dc",
                    Name = "Retrieve the details for product 1",
                    Url = "http://localhost:5000/api/v1/products/1",
                    ParentId = "13e2f21a-4283-4ff8-bb7a-096e7b89e0f0",
                    SortOrder = 2,
                    CssClass = "ProductApi"
                },
                new Function()
                {
                    Id = "1156b66d-ef2f-471e-9e37-44dfb2aea415",
                    Name = "Create a new product",
                    Url = "http://localhost:5000/api/v1/products",
                    ParentId = "13e2f21a-4283-4ff8-bb7a-096e7b89e0f0",
                    SortOrder = 2,
                    CssClass = "ProductApi"
                },
                new Function()
                {
                    Id = "8344a326-5e0f-4389-a251-832aae182286",
                    Name = "Update the details of product 1 if it exists",
                    Url = "http://localhost:5000/api/v1/products/1",
                    ParentId = "13e2f21a-4283-4ff8-bb7a-096e7b89e0f0",
                    SortOrder = 2,
                    CssClass = "ProductApi"
                },
                new Function()
                {
                    Id = "e4bb65d0-3ff6-4182-af22-33a91e844af9",
                    Name = "Remove product 1",
                    Url = "http://localhost:5000/api/v1/products/1",
                    ParentId = "13e2f21a-4283-4ff8-bb7a-096e7b89e0f0",
                    SortOrder = 2,
                    CssClass = "ProductApi"
                },
            };

            builder.HasData(functions);
        }
    }
}