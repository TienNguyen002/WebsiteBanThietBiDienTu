using Azure;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DeviceWebDbContext context) : base(context) { }

        /// <summary>
        /// Delete Product By Id
        /// </summary>
        /// <param name="id">Id of product want to delete</param>
        /// <returns>Deleted Product</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteProduct(int id)
        {
            var productToDelete = await _context.Set<Product>()
                .Include(p => p.Branch)
                .Include(p => p.Category)
                .Include(p => p.Tag)
                .Include(p => p.Images)
                .Include(p => p.Colors)
                .Include(p => p.Comments)
                .Include(p => p.Discounts)
                .Include(p => p.OrderItems)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            try
            {
                _context.Remove(productToDelete);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Get All Product By Tag
        /// </summary>
        /// <param name="tag">Tag of product want to get</param>
        /// <returns>A list of product getting by tag</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<Product>> GetAllProductByTag(string tag)
        {
            return await _context.Set<Product>()
                .Where(p => p.Tag.UrlSlug.Contains(tag))
                .ToListAsync();
        }

        public async Task<Product> GetProductBySlug(string slug)
        {
            return await _context.Set<Product>()
                .Where(p => p.UrlSlug.Contains(slug))
                .FirstOrDefaultAsync();
        }
    }
}
