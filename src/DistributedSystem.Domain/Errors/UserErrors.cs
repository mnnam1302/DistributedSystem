using DistributedSystem.Contract.Abstractions.Shared;

namespace DistributedSystem.Domain.Errors
{
    public static class UserErrors
    {
        public static Error NotFound(Guid id) =>
            new Error("Users.NotFound", $"The user with the Id = '{id}' was not found.");
    }
}