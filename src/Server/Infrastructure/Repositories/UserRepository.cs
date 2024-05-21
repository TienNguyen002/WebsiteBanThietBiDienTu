using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DeviceWebDbContext _context;
        public UserRepository(UserManager<ApplicationUser> userManager, DeviceWebDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IList<ApplicationUser>> GetAllUsers()
        {
            return await _userManager.Users
                .Include(u => u.Orders)
                .ThenInclude(x => x.OrderItems)
                .ThenInclude(x => x.Product)
                .Include(x => x.Orders)
                .ThenInclude(x => x.Discount)
                .Include(x => x.Orders)
                .ThenInclude(x => x.PaymentMethod)
                .Include(x => x.Orders)
                .ThenInclude(x => x.Status)
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
