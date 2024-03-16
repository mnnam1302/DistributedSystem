using DistributedSystem.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Action = DistributedSystem.Domain.Entities.Identity.Action;

namespace DistributedSystem.Persistence.Configurations
{
    internal class ActionConfiguration : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            builder.ToTable(TableNames.Actions);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasMaxLength(50);
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.SortOrder).HasDefaultValue(null);

            // Each User can have many Permissions
            // 1 - n
            builder.HasMany(e => e.Permissions)
                .WithOne()
                .HasForeignKey(p => p.ActionId)
                .IsRequired();

            // Each User can have many ActionInFunctions
            // 1 - n relationship (1 because IsRequired)
            builder.HasMany(e => e.ActionInFunctions)
                .WithOne()
                .HasForeignKey(aif => aif.ActionId)
                .IsRequired();

            var actions = new List<Action>()
            {
                new Action()
                {
                    Id = "9c955674-7377-4b52-b5f4-82eab10fe6ed",
                    Name = "GET",
                    SortOrder = 1,
                    IsActive = true,
                },
                new Action()
                {
                    Id = "3e700c49-37ee-4baa-8384-b1fe9f95f822",
                    Name = "POST",
                    SortOrder = 1,
                    IsActive = true,
                },
                new Action()
                {
                    Id = "51e900fa-9445-486f-bd27-47bb1684673d",
                    Name = "PUT",
                    SortOrder = 1,
                    IsActive = true,
                },
                new Action()
                {
                    Id = "8892ffdc-c7af-49cd-af76-d221c6642799",
                    Name = "DELETE",
                    SortOrder = 1,
                    IsActive = true,
                }
            };

            builder.HasData(actions);
        }
    }
}