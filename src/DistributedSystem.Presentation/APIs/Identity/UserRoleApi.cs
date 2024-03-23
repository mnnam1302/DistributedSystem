using Carter;
using DistributedSystem.Contract.Services.V1.Identity;
using DistributedSystem.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DistributedSystem.Presentation.APIs.Identity;

public class UserRoleApi : ApiEndpoint, ICarterModule
{
    private const string BaseUrl = "api/v{version:apiVersion}/users";

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group1 = app.NewVersionedApi("user-roles")
            .MapGroup(BaseUrl).HasApiVersion(1);

        group1.MapPost("{userId}/roles", CreateRolesToUserV1);
        group1.MapGet("{userId}/roles", GetRolesByUserIdV1);
    }

    private static async Task<IResult> CreateRolesToUserV1(ISender Sender, Guid userId, [FromBody] Command.CreateAppUserRoleCommand request)
    {
        var createUserRoleCommand = new Command.CreateAppUserRoleCommand(userId, request.RoleId);

        var result = await Sender.Send(createUserRoleCommand);

        if (result.IsFailure)
            return HandlerFailure(result);

        return Results.Ok(result);
    }

    private static async Task<IResult> GetRolesByUserIdV1(ISender Sender, 
        Guid userId)
    {
        var getUserRolesByUserIdQuery = new Query.GetAppUserRolesByUserIdQuery(userId);

        var result = await Sender.Send(getUserRolesByUserIdQuery);

        if (result is null)
            return HandlerFailure(result);

        return Results.Ok(result);
    }
}
