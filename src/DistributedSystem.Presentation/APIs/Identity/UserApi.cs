using Carter;
using DistributedSystem.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DistributedSystem.Presentation.APIs.Identity
{
    public class UserApi : ApiEndpoint, ICarterModule
    {
        private const string BaseUrl = "/api/v{version:apiVersion}/users";

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group1 = app.NewVersionedApi("users")
                .MapGroup(BaseUrl).HasApiVersion(1);

            group1.MapPost("", RegisterUsersV1);
        }

        private static async Task<IResult> RegisterUsersV1(ISender Sender, [FromBody] Contract.Services.V1.Identity.Command.RegisterUserCommand registerUserCommand)
        {
            var result = await Sender.Send(registerUserCommand);

            if (result.IsFailure)
                return HandlerFailure(result);

            return Results.Ok(result);
        }
    }
}