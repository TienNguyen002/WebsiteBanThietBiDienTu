using Core.DTO.User;
using Core.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Customers
{
    public class UserRepository : IUserRepository
    {
        private readonly WebDbContext _context;
        public UserRepository(WebDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IList<UserItems>> GetCustomersAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<User> customers = _context.Set<User>()
                .Include(c => c.Comments);
            return await customers
                .OrderBy(c => c.Id)
                .Select(c => new UserItems()
                {
                    Id = c.Id,
                    Name = c.Name,
                    UrlSlug = c.UrlSlug,
                    Email = c.Email,
                    Phone = c.Phone,
                })
                .ToListAsync();
        }

        public async Task<User> GetCustomerBySlugAsync(string slug, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            if (!includeDetails)
            {
                return await _context.Set<User>()
                    .Where(c => c.UrlSlug == slug)
                    .FirstOrDefaultAsync(cancellationToken);
            }
            return await _context.Set<User>()
                .Include(c => c.Comments)
                .Where(c => c.UrlSlug == slug)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
