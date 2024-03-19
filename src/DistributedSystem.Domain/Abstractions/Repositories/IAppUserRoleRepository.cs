using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedSystem.Domain.Abstractions.Repositories
{
    public interface IAppUserRoleRepository
    {
        void Add(IdentityUserRole<Guid> userRole);

        //void Update(IdentityUserRole<Guid> userRole);

        //void Delete(IdentityUserRole<Guid> userRole);
    }
}
