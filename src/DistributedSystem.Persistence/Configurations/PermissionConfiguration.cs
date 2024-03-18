using DistributedSystem.Domain.Entities.Identity;
using DistributedSystem.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistributedSystem.Persistence.Configurations
{
    internal sealed class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable(TableNames.Permissions);

            builder.HasKey(x => new { x.RoleId, x.FunctionId, x.ActionId });

            // Admin
            var admin_permissions = new List<Permission>()
            {
                new Permission()
                {
                    RoleId = Guid.Parse("424C4755-379E-440C-B67E-D53A4D615113"),
                    ActionId = "3e700c49-37ee-4baa-8384-b1fe9f95f822", // POST
                    FunctionId = "1156b66d-ef2f-471e-9e37-44dfb2aea415" // Create Product
                },
                new Permission()
                {
                    RoleId = Guid.Parse("424C4755-379E-440C-B67E-D53A4D615113"),
                    ActionId = "51e900fa-9445-486f-bd27-47bb1684673d", // PUT
                    FunctionId = "8344a326-5e0f-4389-a251-832aae182286" // Update Product
                },
                new Permission()
                {
                    RoleId = Guid.Parse("424C4755-379E-440C-B67E-D53A4D615113"),
                    ActionId = "8892ffdc-c7af-49cd-af76-d221c6642799", // DELETE
                    FunctionId = "e4bb65d0-3ff6-4182-af22-33a91e844af9" // Delete Product
                },
                new Permission()
                {
                    RoleId = Guid.Parse("424C4755-379E-440C-B67E-D53A4D615113"),
                    ActionId = "9c955674-7377-4b52-b5f4-82eab10fe6ed", // GET
                    FunctionId = "1b8c6511-d1db-4c01-b65a-1c60ec0bf90c" // Retrive all Products
                },
                new Permission()
                {
                    RoleId = Guid.Parse("424C4755-379E-440C-B67E-D53A4D615113"),
                    ActionId = "9c955674-7377-4b52-b5f4-82eab10fe6ed", // GET
                    FunctionId = "401b7a1d-6489-4b0e-9dc7-a27277d6e3dc" // Retrive Product by Id
                }
            };

            // User
            var user_permissions = new List<Permission>()
            {
                new Permission()
                {
                    RoleId = Guid.Parse("0D395FBD-3271-44A2-B147-4B77BE0464E6"),
                    ActionId = "9c955674-7377-4b52-b5f4-82eab10fe6ed", // GET
                    FunctionId = "1b8c6511-d1db-4c01-b65a-1c60ec0bf90c" // Retrive all Products
                },
                new Permission()
                {
                    RoleId = Guid.Parse("0D395FBD-3271-44A2-B147-4B77BE0464E6"),
                    ActionId = "9c955674-7377-4b52-b5f4-82eab10fe6ed", // GET
                    FunctionId = "401b7a1d-6489-4b0e-9dc7-a27277d6e3dc" // Retrive Product by Id
                }
            };

            builder.HasData(admin_permissions);
            builder.HasData(user_permissions);
        }
    }
}