using Core.DTO.Specification;
using Core.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Specifications
{
    public class SpecificationRepository : ISpecificationRepository
    {
        private readonly WebDbContext _context;
        public SpecificationRepository(WebDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddOrUpdateSpecificationAsync(Specification specification, CancellationToken cancellationToken = default)
        {
            if (specification.Id > 0)
            {
                _context.Update(specification);
            }
            else
            {
                _context.Add(specification);
            }
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> DeleteSpecificationAsync(int id, CancellationToken cancellationToken = default)
        {
            var specificationDelete = await _context.Set<Specification>()
                .Include(s => s.SpecificationCategory)
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
            if (specificationDelete == null)
            {
                return false;
            }
            _context.Remove(specificationDelete);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IList<SpecificationItems>> GetAllSpecificationsAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<Specification> specifications = _context.Set<Specification>();
            return await specifications
                .Include(s => s.SpecificationCategory)
                .OrderBy(s => s.Id)
                .Select(s => new SpecificationItems()
                {
                    Id = s.Id,
                    SpecificationCategory = s.SpecificationCategory.Name,
                    Details = s.Details,
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<Specification> GetSpecificationByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Specification>()
                .Include(s => s.SpecificationCategory)
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
