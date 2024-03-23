using DistributedSystem.Domain.Entities.Identity;
using DistributedSystem.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistributedSystem.Persistence.Configurations;

internal sealed class ActionInFunctionConfiguration : IEntityTypeConfiguration<ActionInFunction>
{
    public void Configure(EntityTypeBuilder<ActionInFunction> builder)
    {
        builder.ToTable(TableNames.ActionInFunctions);

        builder.HasKey(x => new { x.ActionId, x.FunctionId });

        var actionInFunctions = new List<ActionInFunction>()
        {
            new ActionInFunction()
            {
                ActionId = "3e700c49-37ee-4baa-8384-b1fe9f95f822", // POST
                FunctionId = "1156b66d-ef2f-471e-9e37-44dfb2aea415"
            },
            new ActionInFunction()
            {
                ActionId = "51e900fa-9445-486f-bd27-47bb1684673d", // PUT
                FunctionId = "8344a326-5e0f-4389-a251-832aae182286"
            },
            new ActionInFunction()
            {
                ActionId = "8892ffdc-c7af-49cd-af76-d221c6642799", // DELETE
                FunctionId = "e4bb65d0-3ff6-4182-af22-33a91e844af9"
            },
            new ActionInFunction()
            {
                ActionId = "9c955674-7377-4b52-b5f4-82eab10fe6ed", // GET
                FunctionId = "1b8c6511-d1db-4c01-b65a-1c60ec0bf90c"
            },
            new ActionInFunction()
            {
                ActionId = "9c955674-7377-4b52-b5f4-82eab10fe6ed", // GET
                FunctionId = "401b7a1d-6489-4b0e-9dc7-a27277d6e3dc"
            }
        };

        builder.HasData(actionInFunctions);
    }
}
