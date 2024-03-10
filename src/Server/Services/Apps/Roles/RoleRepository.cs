using Core.DTO.Role;
using Core.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Roles
{
    public class RoleRepository : IRoleRepository
    {
        private readonly WebDbContext _context;
        public RoleRepository(WebDbContext context)
        {
            _context = context;
        }

        public async Task<IList<RoleItems>> GetAllRolesAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<Role> roles = _context.Set<Role>();  
            return await roles
                .OrderBy(r => r.Id)
                .Select(r => new RoleItems()
                {
                    Id = r.Id,
                    Name = r.Name,
                    UrlSlug = r.UrlSlug,
                })
                .ToListAsync(cancellationToken);
        }
    }
}
