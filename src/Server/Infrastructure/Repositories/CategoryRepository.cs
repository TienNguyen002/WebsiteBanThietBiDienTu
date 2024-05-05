using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DeviceWebDbContext context) : base(context) { }

        /// <summary>
        /// Delete Category By Id
        /// </summary>
        /// <param name="id"> Id Of Category want to delete </param>
        /// <returns> Deleted Category </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteCategory(int id)
        {
            var categoryToDelete = await _context.Set<Category>()
                .Include(c => c.Series)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
            try
            {
                _context.Remove(categoryToDelete);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Get Category By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get Category </param>
        /// <returns> Category With UrlSlug want to get </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<Category> GetCategoryBySlug(string slug)
        {
            return await _context.Set<Category>()
                .Include(c => c.Series)
                .ThenInclude(s => s.Products)
                .Where(c => c.UrlSlug == slug)
                .FirstOrDefaultAsync();
        }
    }
}
