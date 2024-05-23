using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(DeviceWebDbContext context) : base(context)
        {
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
