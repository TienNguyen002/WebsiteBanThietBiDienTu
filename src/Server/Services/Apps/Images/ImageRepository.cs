using Core.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Images
{
    public class ImageRepository : IImageRepository
    {
        private readonly WebDbContext _context;
        public ImageRepository(WebDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteImage(int id, CancellationToken cancellationToken = default)
        {
            var imageDelete = await _context.Set<Image>()
                .Include(c => c.Product)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
            if (imageDelete == null)
            {
                return false;
            }
            _context.Remove(imageDelete);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Image> GetImageByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Image>()
                .Include(c => c.Product)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
