using DistributedSystem.Domain.Abstractions.Repositories;
using Microsoft.AspNetCore.Identity;

namespace DistributedSystem.Persistence.Repositories
{
    public class AppUserRoleRepository : IAppUserRoleRepository, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;

        public AppUserRoleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public void Add(IdentityUserRole<Guid> userRole)
        {
            _dbContext.IdentityUserRoles.Add(userRole);
        }
    }
}