using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SerieRepository : GenericRepository<Serie>, ISerieRepository
    {
        public SerieRepository(DeviceWebDbContext context) : base(context) { }

        public async Task<bool> DeleteSerie(int id)
        {
            var serieToDelete = await _context.Set<Serie>()
                .Include(p => p.Products)
                .Include(p => p.Images)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            try
            {
                _context.Remove(serieToDelete);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IList<Serie>> GetAllSeries()
        {
            return await _context.Set<Serie>()
                .Include(s => s.Category)
                .Include(s => s.Branch)
                .Include(s => s.Products)
                .Include(s => s.Images)
                .ToListAsync();
        }

        public async Task<Serie> GetSerieById(int id)
        {
            return await _context.Set<Serie>()
                .Include(c => c.Branch)
                .Include(c => c.Category)
                .Include(c => c.Images)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Serie> GetSerieByProductSlug(string slug)
        {
            return await _context.Set<Serie>()
                .Include(s => s.Products)
                .Where(s => s.Products.Any(p => p.UrlSlug == slug))
                .FirstOrDefaultAsync();
        }

        public async Task<Serie> GetSerieBySlug(string slug)
        {
            return await _context.Set<Serie>()
                .Include(s => s.Products)
                .ThenInclude(s => s.Colors)
                .Include(s => s.Images)
                .Where(s => s.UrlSlug == slug)
                .FirstOrDefaultAsync();
        }
    }
}
