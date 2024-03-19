using Dapper;
using DistributedSystem.Contract.Abstractions.Message;
using DistributedSystem.Contract.Abstractions.Shared;
using DistributedSystem.Contract.Services.V1.Identity;
using DistributedSystem.Domain.Abstractions.Repositories;
using DistributedSystem.Domain.Entities.Identity;
using DistributedSystem.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace DistributedSystem.Application.UseCases.V1.Queries.Identity
{
    public class GetAppUserRolesByUserIdQueryHandler : IQueryHandler<Query.GetAppUserRolesByUserIdQuery, List<Response.UserRoleResponse>>
    {
        private readonly IDapperRepositoryBase _dapperRepositoryBase;

        public GetAppUserRolesByUserIdQueryHandler(IDapperRepositoryBase dapperRepositoryBase)
        {
            _dapperRepositoryBase = dapperRepositoryBase;
        }

        public async Task<Result<List<Response.UserRoleResponse>>> Handle(Query.GetAppUserRolesByUserIdQuery request, CancellationToken cancellationToken)
        {
            string sqlUserQuery =
                """
                SELECT u.Id, u.FirstName, u.LastName, u.FullName, u.Email, u.DateOfBirth, u.IsDirector, u.IsHeadOfDepartment, u.ManagerId, u.PhoneNumber
                FROM AppUsers u
                WHERE u.Id = @UserId
                """;

            var user = await _dapperRepositoryBase.QueryFirstOrDefaultAsync<Response.UserResponse>(
                sqlUserQuery,
                new { request.UserId });

            if (user is null)
                throw new IdentityException.UserNotFoundException(request.UserId);

            string sqlUserRolesQuery =
                """
                select r.Id, r.Name
                from AppUsers u, AppUserRoles ur, AppRoles r
                where u.Id = @userId and u.Id = ur.UserId and ur.RoleId = r.Id;
                """;

            var result = await _dapperRepositoryBase.QueryAsync<Response.UserRoleResponse>(
                sqlUserRolesQuery,
                new { request.UserId });

            //string sqlUserRolesQuery =
            //   """
            //    select u.Id, u.FullName, r.Id, r.Name
            //    from AppUsers u, AppUserRoles ur, AppRoles r
            //    where u.Id = @userId and u.Id = ur.UserId and ur.RoleId = r.Id;
            //    """;

            //string sqlUserRolesQuery = 
            //    """
            //    select u.Id, u.FullName, r.Id, r.Name
            //    from AppUsers u, AppUserRoles ur, AppRoles r
            //    where u.Id = @userId and u.Id = ur.UserId and ur.RoleId = r.Id;
            //    """;

            //var result = await _dapperRepositoryBase
            //    .QueryMapAsync<Response.UserResponse, AppRole, Response.UserRoleResponse>(
            //        sqlUserRolesQuery,
            //        (user, role) =>
            //        {
            //            var userRole = new Response.UserRoleResponse
            //            {
            //                FullName = user.FullName,
            //                RoleName = role.Name
            //            };

            //            return userRole;
            //        },
            //        new { request.UserId },
            //        splitOn: "FullName, Name",
            //        cancellationToken: cancellationToken
            //    );

            return Result.Success(result.ToList());
        }
    }
}