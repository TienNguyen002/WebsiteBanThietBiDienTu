using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        public ImageRepository(DeviceWebDbContext context) : base(context) { }

        /// <summary>
        /// Delete Image By Id
        /// </summary>
        /// <param name="id"> Id Of Image want to delete </param>
        /// <returns> Deleted Image </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteImage(int id)
        {
            var imageToDelete = await _context.Set<Image>()
                .Include(i => i.Product)
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
            try
            {
                _context.Remove(imageToDelete);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
