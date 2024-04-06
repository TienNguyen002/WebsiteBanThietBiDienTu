using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ColorRepository : GenericRepository<Color>, IColorRepository
    {
        public ColorRepository(DeviceWebDbContext context) : base(context) { }

        /// <summary>
        /// Delete Color By Id
        /// </summary>
        /// <param name="id"> Id Of Color want to delete </param>
        /// <returns> Deleted Color </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteColor(int id)
        {
            var colorToDelete = await _context.Set<Color>()
                .Include(c => c.Products)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
            try
            {
                _context.Remove(colorToDelete);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Get Color By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get Color </param>
        /// <returns> Color With UrlSlug want to get </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<Color> GetColorBySlug(string slug)
        {
            return await _context.Set<Color>()
                .Include(c => c.Products)
                .Where(c => c.UrlSlug == slug)
                .FirstOrDefaultAsync();
        }
    }
}
