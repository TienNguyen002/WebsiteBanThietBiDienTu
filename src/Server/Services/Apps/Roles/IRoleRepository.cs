using Core.DTO.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Roles
{
    public interface IRoleRepository
    {
        //Lấy ds Role
        public Task<IList<RoleItems>> GetAllRolesAsync(CancellationToken cancellationToken = default);
    }
}
