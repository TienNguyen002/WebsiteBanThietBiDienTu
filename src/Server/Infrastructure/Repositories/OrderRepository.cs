using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DeviceWebDbContext context) : base(context) {}

        public async Task<int> CountOrders()
        {
            return await _context.Set<Order>().CountAsync();
        }

        public async Task<IList<Order>> GetAllOrders()
        {
            return await _context.Set<Order>()
                .Include(o => o.OrderItems)
                .ThenInclude(o => o.Product)
                .Include(o => o.ApplicationUser)
                .Include(o => o.Status)
                .Include(o => o.PaymentMethod)
                .ToListAsync();
        }

        public async Task<IList<Order>> GetOrdersByUserIdAsync(string userId)
        {
            return await _context.Set<Order>()
                .Include(x => x.OrderItems)
                .Include(x => x.Status)
                .Include(x => x.PaymentMethod)
                .Include(x => x.Discount)
                .Where(order => order.ApplicationUserId == userId)
                .ToListAsync();
        }
    }
}
