using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        public SaleRepository(DeviceWebDbContext context) : base(context)
        {
        }

        public async Task<Sale> GetCurrentSale(int id)
        {
            return await _context.Set<Sale>()
                .Include(b => b.Products)
                .ThenInclude(p => p.Colors)
                .Where(b => b.Id == id && b.Status == true)
                .FirstOrDefaultAsync();
        }
    }
}
