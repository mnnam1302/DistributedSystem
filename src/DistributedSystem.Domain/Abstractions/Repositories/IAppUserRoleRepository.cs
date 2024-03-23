using Microsoft.AspNetCore.Identity;

namespace DistributedSystem.Domain.Abstractions.Repositories;

public interface IAppUserRoleRepository
{
    void Add(IdentityUserRole<Guid> userRole);

    //void Update(IdentityUserRole<Guid> userRole);

    //void Delete(IdentityUserRole<Guid> userRole);
}
