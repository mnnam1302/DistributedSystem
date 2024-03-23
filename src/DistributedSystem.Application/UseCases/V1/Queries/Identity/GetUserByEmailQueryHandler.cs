using AutoMapper;
using DistributedSystem.Contract.Abstractions.Message;
using DistributedSystem.Contract.Abstractions.Shared;
using DistributedSystem.Contract.Services.V1.Identity;
using DistributedSystem.Domain.Abstractions.Repositories;
using DistributedSystem.Domain.Exceptions;

namespace DistributedSystem.Application.UseCases.V1.Queries.Identity;

public class GetUserByEmailQueryHandler : IQueryHandler<Query.GetUserByEmailQuery, Response.UserResponse>
{
    private readonly IDapperRepositoryBase _dapperRepository;
    private readonly IMapper _mapper;

    public GetUserByEmailQueryHandler(IDapperRepositoryBase dapperRepository, IMapper mapper)
    {
        _dapperRepository = dapperRepository;
        _mapper = mapper;
    }

    public async Task<Result<Response.UserResponse>> Handle(Query.GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        const string sql =
            """
            SELECT u.Id, u.FirstName, u.LastName, u.FullName, u.Email, u.DateOfBirth, u.IsDirector, u.IsHeadOfDepartment, u.ManagerId, u.PhoneNumber
            FROM AppUsers u
            WHERE u.Email = @Email
            """;

        var user = await _dapperRepository.QueryFirstOrDefaultAsync<Response.UserResponse>(sql, new { request.Email }, cancellationToken)
            ?? throw new IdentityException.UserNotFoundByEmailException(request.Email);

        var result = _mapper.Map<Response.UserResponse>(user);

        return Result.Success(result);
    }
}
