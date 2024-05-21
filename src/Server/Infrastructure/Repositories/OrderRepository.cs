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

        public async Task<IList<OrderItem>> GetOrderItemsByOrderIdAsync(int id)
        {
            return await _context.Set<OrderItem>()
                .Include(x => x.Order)
                .Include(x => x.Product)
                .Where(order => order.Order.Id == id)
                .ToListAsync();
        }
    }
}
