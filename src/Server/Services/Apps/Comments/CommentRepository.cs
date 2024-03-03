using Core.DTO.Comment;
using Core.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Comments
{
    public class CommentRepository : ICommentRepository
    {
        private readonly WebDbContext _context;
        private readonly IMemoryCache _memoryCache;
        public CommentRepository(WebDbContext dbContext, IMemoryCache memoryCache)
        {
            _context = dbContext;
            _memoryCache = memoryCache;
        }   

        public async Task<IList<CommentItems>> GetCommentsAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<Comment> comments = _context.Set<Comment>()
                .Include(c => c.Customer)
                .Include(p => p.Product);
            return await comments
                .OrderBy(c => c.Id)
                .Select(c => new CommentItems()
                {
                    Id = c.Id,
                    CustomerName = c.Customer.Name,
                    ProductUrlSlug = c.Product.UrlSlug,
                    Detail = c.Detail,
                    CreateDate = c.CreatedDate,
                })
                .ToListAsync();
        }

        public async Task<IList<CommentItems>> GetCommentsByProductSlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            IQueryable<Comment> comments = _context.Set<Comment>()
                .Include(c => c.Customer)
                .Include(p => p.Product);
            return await comments
                .Where(c => c.Product.UrlSlug == slug)  
                .OrderBy(c => c.Id)
                .Select(c => new CommentItems()
                {
                    Id = c.Id,
                    CustomerName = c.Customer.Name,
                    Detail = c.Detail,
                    CreateDate = c.CreatedDate,
                })
                .ToListAsync();
        }

        public async Task<bool> AddCommentAsync(Comment comment, string productSlug, CancellationToken cancellationToken = default)
        {
            var product = await _context.Set<Product>()
                .Where(p => p.UrlSlug == productSlug)
                .FirstOrDefaultAsync();
            comment.ProductId = product.Id;
            _context.Add(comment);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> DeleteCommentByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var commentToDelete = await _context.Set<Comment>()
                .Include(c => c.Customer)
                .Include(p => p.Product)
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
            if (commentToDelete == null)
            {
                return false;
            }
            _context.Remove(commentToDelete);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
