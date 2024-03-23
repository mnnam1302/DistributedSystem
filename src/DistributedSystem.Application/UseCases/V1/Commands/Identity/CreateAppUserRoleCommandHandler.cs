using DistributedSystem.Contract.Abstractions.Message;
using DistributedSystem.Contract.Abstractions.Shared;
using DistributedSystem.Contract.Services.V1.Identity;
using DistributedSystem.Domain.Abstractions.Repositories;
using DistributedSystem.Domain.Entities.Identity;
using DistributedSystem.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace DistributedSystem.Application.UseCases.V1.Commands.Identity;

public class CreateAppUserRoleCommandHandler : ICommandHandler<Command.CreateAppUserRoleCommand>
{
    private readonly IRepositoryBase<AppUser, Guid> _userReposiory;
    private readonly IRepositoryBase<AppRole, Guid> _roleRepository;
    private readonly IAppUserRoleRepository _appUserRoleRepository;

    public CreateAppUserRoleCommandHandler(IRepositoryBase<AppUser, Guid> userReposiory,
        IRepositoryBase<AppRole, Guid> roleRepository,
        IAppUserRoleRepository appUserRoleRepository)
    {
        _userReposiory = userReposiory;
        _roleRepository = roleRepository;
        _appUserRoleRepository = appUserRoleRepository;
    }


    /// <summary>
    /// 1. Check USER exists
    /// 2. Check ROLE exists
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Result> Handle(Command.CreateAppUserRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await _userReposiory.FindByIdAsync(request.UserId, cancellationToken)
            ?? throw new IdentityException.UserNotFoundException(request.UserId);

        var role = await _roleRepository.FindByIdAsync(request.RoleId, cancellationToken)
            ?? throw new IdentityException.RoleNotFoundException(request.RoleId);

        var userRole = new IdentityUserRole<Guid>
        {
            UserId = request.UserId,
            RoleId = request.RoleId
        };

        _appUserRoleRepository.Add(userRole);

        return Result.Success();
    }
}
