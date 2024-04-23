using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(DeviceWebDbContext context) : base(context) { }

        /// <summary>
        /// Get All Comment by Product Tag
        /// </summary>
        /// <param name="tag">Tag Of Product want to get all comments</param>
        /// <returns>A List Of Comment</returns>
        /// <exception cref="Exception"></exception>
        public async Task<IList<Comment>> GetCommentsByProductTag(string tag)
        {
            return await _context.Set<Comment>().Where(c => c.Serie.UrlSlug == tag).ToListAsync();   
        }
    }
}
