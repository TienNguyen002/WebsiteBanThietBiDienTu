using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DeviceWebDbContext context) : base(context) {}

        public async Task<IList<Order>> GetAllOrders()
        {
            return await _context.Set<Order>()
                .Include(o => o.OrderItems)
                .ThenInclude(o => o.Product)
                .Include(o => o.User)
                .Include(o => o.Status)
                .Include(o => o.PaymentMethod)
                .ToListAsync();
        }
    }
}
