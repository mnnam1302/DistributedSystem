using Carter;
using DistributedSystem.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DistributedSystem.Presentation.APIs.Identity;

public class UserApi : ApiEndpoint, ICarterModule
{
    private const string BaseUrl = "/api/v{version:apiVersion}/users";

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group1 = app.NewVersionedApi("users")
            .MapGroup(BaseUrl).HasApiVersion(1);

        group1.MapPost("", RegisterUsersV1);

        group1.MapGet("", GetUsersByEmailV1);
        //group1.MapGet("", GetUsersV1);
        //group1.MapGet("{userId}", UpdateUsersV1);
        //group1.MapGet("{userId}", DeleteUsersV1);
    }

    #region ================= Version 01 =====================
    private static async Task<IResult> RegisterUsersV1(ISender Sender, [FromBody] Contract.Services.V1.Identity.Command.RegisterUserCommand registerUserCommand)
    {
        var result = await Sender.Send(registerUserCommand);

        if (result.IsFailure)
            return HandlerFailure(result);

        return Results.Ok(result);
    }

    private static async Task<IResult> GetUsersByEmailV1(ISender Sender, [FromQuery] string email)
    {
        var getUserByEmailQuery = new Contract.Services.V1.Identity.Query.GetUserByEmailQuery(email);

        var result = await Sender.Send(getUserByEmailQuery);

        if (result.IsFailure)
            return HandlerFailure(result);

        return Results.Ok(result);
    }

    #endregion ================= Version 01 =====================
}
