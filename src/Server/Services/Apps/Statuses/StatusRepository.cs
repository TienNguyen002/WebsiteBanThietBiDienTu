using Core.DTO.Status;
using Core.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Statuses
{
    public class StatusRepository : IStatusRepository
    {
        private readonly WebDbContext _context;
        public StatusRepository(WebDbContext context)
        {
            _context = context;
        }

        public async Task<IList<StatusItems>> GetAllStatusAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<Status> statuses = _context.Set<Status>();
            return await statuses
                .OrderBy(s => s.Id)
                .Select(s => new StatusItems()
                {
                    Id = s.Id,
                    Name = s.Name,
                    UrlSlug = s.UrlSlug,
                })
                .ToListAsync(cancellationToken);
        }
    }
}
