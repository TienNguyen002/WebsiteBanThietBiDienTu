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
        private readonly WebDbContext _dbContext;
        private readonly IMemoryCache _memoryCache;

        public CategoryRepository(WebDbContext dbContext, IMemoryCache memoryCache)
        {
            _dbContext = dbContext;
            _memoryCache = memoryCache;
        }

        public async Task<IList<CategoryItems>> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<Category> categories = _dbContext.Set<Category>();
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
    }
}
