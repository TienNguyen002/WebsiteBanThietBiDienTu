using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SerieRepository : GenericRepository<Serie>, ISerieRepository
    {
        public SerieRepository(DeviceWebDbContext context) : base(context) { }

        public async Task<IList<Serie>> GetAllSeries()
        {
            return await _context.Set<Serie>()
                .Include(s => s.Category)
                .Include(s => s.Branch)
                .Include(s => s.Products)
                .Include(s => s.Images)
                .ToListAsync();
        }
    }
}
