using AutoMapper;
using DistributedSystem.Contract.Abstractions.Message;
using DistributedSystem.Contract.Abstractions.Shared;
using DistributedSystem.Contract.Services.V1.Identity;
using DistributedSystem.Domain.Exceptions;
using DistributedSystem.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DistributedSystem.Application.UseCases.V1.Queries.Identity
{
    public class GetUserByEmailQueryHandler : IQueryHandler<Query.GetUserByEmailQuery, Response.UserResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserByEmailQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Result<Response.UserResponse>> Handle(Query.GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
               .AsNoTracking()
               .Where(u => u.Email == request.Email)
               .FirstOrDefaultAsync(cancellationToken);

            if (user is null)
                throw new IdentityException.UserByEmailNotFoundException(request.Email);

            var result = _mapper.Map<Response.UserResponse>(user);

            return Result.Success(result);
        }
    }
}