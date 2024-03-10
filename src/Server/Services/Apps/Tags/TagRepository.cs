using Core.DTO.Tag;
using Core.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Tags
{
    public class TagRepository : ITagRepository
    {
        private readonly WebDbContext _context;
        public TagRepository(WebDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddOrUpdateTagAsync(Tag tag, CancellationToken cancellationToken = default)
        {
            if (tag.Id > 0)
            {
                _context.Update(tag);
            }
            else
            {
                _context.Add(tag);
            }
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> DeleteTagAsync(int id, CancellationToken cancellationToken = default)
        {
            var tagDelete = await _context.Set<Tag>()
                .Include(t => t.Products)
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
            if (tagDelete == null)
            {
                return false;
            }
            _context.Remove(tagDelete);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IList<TagItems>> GetAllTagsAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<Tag> tags = _context.Set<Tag>();
            return await tags
                .OrderBy(t => t.Id)
                .Include(t => t.Products)
                .Select(s => new TagItems()
                {
                    Id = s.Id,
                    Name = s.Name,
                    UrlSlug = s.UrlSlug,
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<Tag> GetTagByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Tag>()
                .Include(t => t.Products)
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Tag> GetTagBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Tag>()
                .Include(t => t.Products)
                .Where(t => t.UrlSlug.Contains(slug))
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> IsTagExistBySlugAsync(int id, string slug, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Tag>()
                .AnyAsync(c => c.Id != id && c.UrlSlug == slug, cancellationToken);
        }
    }
}
