using Core.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Carts
{
    public class CartRepository : ICartRepository
    {
        private readonly WebDbContext _context;
        public CartRepository(WebDbContext context)
        {
            _context = context;
        }

        public async Task<Cart> AddProductToCartAsync(string userSlug, string productSlug, CancellationToken cancellationToken = default)
        {
            var cart = await _context.Carts.Include(c => c.Products)
                .Where(c => c.User.UrlSlug.Contains(userSlug))
                .FirstOrDefaultAsync(cancellationToken);
            var product = await _context.Products
                .Where(p => p.UrlSlug.Contains(productSlug))
                .FirstOrDefaultAsync(cancellationToken);
            var user = await _context.Users.Where(u => u.UrlSlug.Contains(userSlug)).FirstOrDefaultAsync(cancellationToken);
            if(cart == null || cart.Status == true)
            {
                cart = new Cart()
                {
                    UserId = user.Id,
                    Products = new List<Product>(),
                    Status = false,
                };
                _context.Carts.Add(cart);
            }
            cart.Products.Add(product);
            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task<Cart> GetCartByUserSlugAsync(string userSlug, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Cart>()
                .Include(c => c.User)
                .Include(c => c.Products)
                .Where(c => c.User.UrlSlug.Contains(userSlug) && c.Status == false)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> RemoveCartAsync(string userSlug, CancellationToken cancellationToken = default)
        {
            var cart = await _context.Set<Cart>()
                .Include(c => c.User)
                .Include(c => c.Products)
                .Where(c => c.User.UrlSlug.Contains(userSlug) && c.Status == false)
                .FirstOrDefaultAsync(cancellationToken);
            cart.Status = true;
            _context.Remove(cart);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Cart> RemoveProductFromCartAsync(string userSlug, string productSlug, CancellationToken cancellationToken = default)
        {
            var cart = await _context.Carts.Include(c => c.Products).Where(c => c.User.UrlSlug.Contains(userSlug)).FirstOrDefaultAsync(cancellationToken);
            var product = await _context.Products.Where(p => p.UrlSlug.Contains(productSlug)).FirstOrDefaultAsync(cancellationToken);
            cart.Products.Remove(product);
            await _context.SaveChangesAsync();
            return cart;
        }
    }
}
