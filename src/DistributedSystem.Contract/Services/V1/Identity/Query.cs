using DistributedSystem.Contract.Abstractions.Message;
using DistributedSystem.Contract.Services.V1.Product;

namespace DistributedSystem.Contract.Services.V1.Identity
{
    public static class Query
    {
        public record GetLoginQuery(string Email, string Password) : IQuery<Response.Authenticated>;

        public record GetTokenQuery(string? AccessToken, string? RefreshToken) : IQuery<Response.Authenticated>;
    }
}