using Domain.DTO.Comment;
using Domain.DTO.Product;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(DeviceWebDbContext context) : base(context) { }

        public async Task<CommentCountDTO> CountAllComment(string slug)
        {
            var comments = await _context.Set<Comment>()
                .Where(c => c.Serie.Products.Any(p => p.UrlSlug == slug))
                .ToListAsync();
            var total = comments.Count();
            var total5 = comments.Where(c => c.Rating > 4).Count();
            var total4 = comments.Where(c => c.Rating > 3 && c.Rating <=4).Count();
            var total3 = comments.Where(c => c.Rating > 2 && c.Rating <= 3).Count();
            var total2 = comments.Where(c => c.Rating > 1 && c.Rating <= 2).Count();
            var total1 = comments.Where(c => c.Rating > 0 && c.Rating <= 1).Count();
            return new CommentCountDTO
            {
                TotalRating = total,
                Total5Rating = total5,
                Total4Rating = total4,
                Total3Rating = total3,
                Total2Rating = total2,
                Total1Rating = total1,
            };
        }

        /// <summary>
        /// Get All Comment by Product Tag
        /// </summary>
        /// <param name="tag">Tag Of Product want to get all comments</param>
        /// <returns>A List Of Comment</returns>
        /// <exception cref="Exception"></exception>
        public async Task<IList<Comment>> GetCommentsByProductSlug(string slug)
        {
            return await _context.Set<Comment>().Include(c => c.ApplicationUser).Where(c => c.Serie.Products.Any(p => p.UrlSlug == slug)).ToListAsync();   
        }
    }
}
