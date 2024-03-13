using Core.DTO.Trademark;
using Core.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Trademarks
{
    public class TrademarkRepository : ITrademarkRepository
    {
        private readonly WebDbContext _context;
        public TrademarkRepository(WebDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddOrUpdateTrademarkAsync(Trademark trademark, CancellationToken cancellationToken = default)
        {
            if (trademark.Id > 0)
            {
                _context.Update(trademark);
            }
            else
            {
                _context.Add(trademark);
            }
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> DeleteTrademarkAsync(int id, CancellationToken cancellationToken = default)
        {
            var speCategoryDelete = await _context.Set<Trademark>()
                .Include(t => t.Categories)
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
            if (speCategoryDelete == null)
            {
                return false;
            }
            _context.Remove(speCategoryDelete);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IList<TrademarkItems>> GetAllTrademarksAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<Trademark> trademarks = _context.Set<Trademark>();
            return await trademarks
                .Include(t => t.Categories)
                .OrderBy(t => t.Id)
                .Select(t => new TrademarkItems()
                {
                    Id = t.Id,
                    Name = t.Name,
                    UrlSlug = t.UrlSlug,
                })
                .ToListAsync(cancellationToken);  
        }

        public async Task<Trademark> GetTrademarkByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Trademark>()
                .Include(t => t.Categories)
                .Include(t => t.Products)
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Trademark> GetTrademarkBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Trademark>()
                .Include(t => t.Categories)
                .Include(t => t.Products)
                .Where(t => t.UrlSlug.Contains(slug))
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> IsTrademarkExistBySlugAsync(int id, string slug, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Trademark>()
                .AnyAsync(c => c.Id != id && c.UrlSlug == slug, cancellationToken);
        }
    }
}
