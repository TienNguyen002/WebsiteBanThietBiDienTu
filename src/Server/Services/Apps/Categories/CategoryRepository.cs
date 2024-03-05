using Core.DTO.Category;
using Core.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly WebDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public CategoryRepository(WebDbContext dbContext, IMemoryCache memoryCache)
        {
            _context = dbContext;
            _memoryCache = memoryCache;
        }

        public async Task<IList<CategoryItems>> GetAllCategoryAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<Category> categories = _context.Set<Category>();
            return await categories
                .OrderBy(c => c.Id)
                .Select(c => new CategoryItems()
                {
                    Id = c.Id,
                    Name = c.Name,
                    UrlSlug = c.UrlSlug
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> IsCategoryExistBySlugAsync(
            int id,
            string slug,
            CancellationToken cancellationToken = default)
        {
            return await _context.Set<Category>()
                .AnyAsync(c => c.Id != id && c.UrlSlug == slug, cancellationToken);
        }

        public async Task<Category> GetCategoryByIdAsync(
            int id,
            bool includeDetails = false,
            CancellationToken cancellationToken = default)
        {
            if(!includeDetails)
            {
                return await _context.Set<Category>().FindAsync(id);
            }
            return await _context.Set<Category>()
                .Include(c => c.Trademarks)
                .Include(c => c.Products)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Category> GetCategoryBySlugAsync(
            string slug,
            bool includeDetails = false,
            CancellationToken cancellationToken = default)
        {
            if (!includeDetails)
            {
                return await _context.Set<Category>().Where(c => c.UrlSlug == slug)
                    .FirstOrDefaultAsync(cancellationToken);
            }
            return await _context.Set<Category>()
                .Include(c => c.Trademarks)
                .Include(c => c.Products)
                .Where(c => c.UrlSlug == slug)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> AddOrUpdateCategoryAsync(Category category, CancellationToken cancellationToken = default)
        {
            if (category.Id > 0)
            {
                _context.Update(category);
            }
            else
            {
                _context.Add(category);
            }
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> DeleteCategoryByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var categoryToDelete = await _context.Set<Category>()
                .Include(c => c.Trademarks)
                .Include(c => c.Products)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
            if (categoryToDelete == null)
            {
                return false;
            }
            _context.Remove(categoryToDelete);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
