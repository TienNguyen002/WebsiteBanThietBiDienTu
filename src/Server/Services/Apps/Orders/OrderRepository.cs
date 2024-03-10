using Core.Contracts;
using Core.DTO.Order;
using Core.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly WebDbContext _context;
        public OrderRepository(WebDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddOrderAsync(Order order, CancellationToken cancellationToken = default)
        {
            order.StatusId = 1;
            _context.Add(order);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> DeleteOrder(int id, CancellationToken cancellationToken = default)
        {
            var orderDelete = await _context.Set<Order>()
                .Include(c => c.Cart)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
            if (orderDelete == null)
            {
                return false;
            }
            _context.Remove(orderDelete);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Order> GetOrderByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Order>()
                .Include(c => c.Cart)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }

        private IQueryable<Order> GetOrderByQueryable(OrderQuery query)
        {
            IQueryable<Order> orderQuery = _context.Set<Order>()
                .Include(o => o.Cart);
            if(!string.IsNullOrEmpty(query.Keyword))
            {
                orderQuery = orderQuery.Where(o => o.CustomerName.Contains(query.Keyword));
            }
            if(!string.IsNullOrEmpty(query.Phone))
            {
                orderQuery = orderQuery.Where(o => o.Phone.Contains(query.Keyword));
            }
            if(!string.IsNullOrEmpty(query.Address))
            {
                orderQuery = orderQuery.Where(o => o.Address.Contains(query.Keyword));
            }
            if(query.StatusId > 0)
            {
                orderQuery = orderQuery.Where(o => o.StatusId == query.StatusId);   
            }
            return orderQuery;
        }

        public async Task<IPagedList<T>> GetPagedOrderAsync<T>(OrderQuery query, 
            IPagingParams pagingParams, 
            Func<IQueryable<Order>, IQueryable<T>> mapper, 
            CancellationToken cancellationToken = default)
        {
            IQueryable<Order> orderResult = GetOrderByQueryable(query);
            IQueryable<T> result = mapper(orderResult);
            return await result.ToPagedListAsync(pagingParams, cancellationToken);
        }
    }
}
