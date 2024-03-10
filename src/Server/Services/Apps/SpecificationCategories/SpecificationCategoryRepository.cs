using Core.DTO.SpecificationCategory;
using Core.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.SpecificationCategories
{
    public class SpecificationCategoryRepository : ISpecificationCategoryRepository
    {
        private readonly WebDbContext _context;
        public SpecificationCategoryRepository(WebDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddOrUpdateSpecificationCategoryAsync(SpecificationCategory specificationCategory, CancellationToken cancellationToken = default)
        {
            if (specificationCategory.Id > 0)
            {
                _context.Update(specificationCategory);
            }
            else
            {
                _context.Add(specificationCategory);
            }
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> DeleteSpecificationCategoryAsync(int id, CancellationToken cancellationToken = default)
        {
            var speCategoryDelete = await _context.Set<SpecificationCategory>()
                .Include(s => s.Specifications)
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
            if (speCategoryDelete == null)
            {
                return false;
            }
            _context.Remove(speCategoryDelete);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IList<SpecificationCategoryItems>> GetAllSpecificationCategoriesAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<SpecificationCategory> specificationCategories = _context.Set<SpecificationCategory>();
            return await specificationCategories
                .OrderBy(s => s.Id)
                .Select(s => new SpecificationCategoryItems()
                {
                    Id = s.Id,
                    Name = s.Name,
                    UrlSlug = s.UrlSlug,
                })
                .ToListAsync(cancellationToken);  
        }

        public async Task<SpecificationCategory> GetSpecificationCategoryByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<SpecificationCategory>()
                .Include(s => s.Specifications)
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<SpecificationCategory> GetSpecificationCategoryBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            return await _context.Set<SpecificationCategory>()
                .Include(s => s.Specifications)
                .Where(s => s.UrlSlug.Contains(slug))
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> IsSpecificationCategoryExistBySlugAsync(int id, string slug, CancellationToken cancellationToken = default)
        {
            return await _context.Set<SpecificationCategory>()
                .AnyAsync(c => c.Id != id && c.UrlSlug == slug, cancellationToken);
        }
    }
}
