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
        /// Add Category If Model Has No Id / Update Category If Model Has Id
        /// </summary>
        /// <param name="category"> Model to add/update </param>
        /// <returns> Added/Updated Category </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> AddOrUpdateCategory(Category category)
        {
            try
            {
                if (category.Id > 0)
                {
                    _context.Update(category);
                }
                else
                {
                    _context.Add(category);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Category By Id
        /// </summary>
        /// <param name="id"> Id Of Category want to delete </param>
        /// <returns> Deleted Category </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteCategory(int id)
        {
            var categoryToDelete = await _context.Set<Category>()
                .Include(c => c.Products)
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
                .Include(c => c.Products)
                .Where(c => c.UrlSlug == slug)
                .FirstOrDefaultAsync();
        }
    }
}
