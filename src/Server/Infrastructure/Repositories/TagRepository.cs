using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(DeviceWebDbContext context) : base(context) { }

        /// <summary>
        /// Add Tag
        /// </summary>
        /// <param name="tag"> Model to add </param>
        /// <returns> Added Tag </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> AddTag(Tag tag)
        {
            try
            {
                _context.Add(tag);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Tag By Id
        /// </summary>
        /// <param name="id"> Id Of Tag want to delete </param>
        /// <returns> Deleted Tag </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteTag(int id)
        {
            var tagToDelete = await _context.Set<Tag>()
                .Include(b => b.Products)
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
            try
            {
                _context.Remove(tagToDelete);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Get Tag By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get Tag </param>
        /// <returns> Tag With UrlSlug want to get </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<Tag> GetTagBySlug(string slug)
        {
            return await _context.Set<Tag>()
                .Include(b => b.Products)
                .Where(b => b.UrlSlug == slug)
                .FirstOrDefaultAsync();
        }
    }
}
