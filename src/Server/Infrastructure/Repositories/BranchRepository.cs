using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        public BranchRepository(DeviceWebDbContext context) : base(context) { }

        /// <summary>
        /// Delete Branch By Id
        /// </summary>
        /// <param name="id"> Id Of Branch want to delete </param>
        /// <returns> Deleted Branch </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteBranch(int id)
        {
            var branchToDelete = await _context.Set<Branch>()
                .Include(b => b.Series)
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
            try
            {
                _context.Remove(branchToDelete);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Get All Branches
        /// </summary>
        /// <returns> A List Of Branches </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<Branch>> GetAllBranchesAsync()
        {
            return await _context.Set<Branch>()
               .Include(c => c.Series)
               .ThenInclude(s => s.Products)
               .ToListAsync();
        }

        public Task<Branch> GetBranchByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Branch By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get Branch </param>
        /// <returns> Branch With UrlSlug want to get </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<Branch> GetBranchBySlug(string slug)
        {
            return await _context.Set<Branch>()
                .Include(b => b.Series)
                .ThenInclude(s => s.Products)
                .Where(b => b.UrlSlug == slug)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<Branch>> GetLimitBranchByCategory(int limit, string category)
        {
            return await _context.Set<Branch>()
                .Include(p => p.Series)
                .ThenInclude(s => s.Products)
                .Where(p => p.Series.Any(p => p.Category.UrlSlug.Contains(category)))
                .Take(limit)
                .ToListAsync();
        }
    }
}
