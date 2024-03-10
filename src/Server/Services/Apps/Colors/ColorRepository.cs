using Core.Contracts;
using Core.DTO.Color;
using Core.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Colors
{
    public class ColorRepository : IColorRepository
    {
        private readonly WebDbContext _context;
        public ColorRepository(WebDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddOrUpdateColorAsync(Color color, CancellationToken cancellationToken = default)
        {
            if(color.Id > 0)
            {
                _context.Update(color);
            }
            else
            {
                _context.Add(color);
            }
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> DeleteColor(int id, CancellationToken cancellationToken = default)
        {
            var colorDelete = await _context.Set<Color>()
                .Include(c => c.Products)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
            if(colorDelete == null)
            {
                return false;
            }
            _context.Remove(colorDelete);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Color> GetColorByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Color>()
                .Include(c => c.Products)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Color> GetColorBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Color>()
                .Include(c => c.Products)
                .Where(c => c.UrlSlug.Contains(slug))
                .FirstOrDefaultAsync(cancellationToken);
        }

        private IQueryable<Color> GetColorByQueryable(ColorQuery query)
        {
            IQueryable<Color> colorQuery = _context.Set<Color>()
                .Include(c => c.Products);
            if(!string.IsNullOrEmpty(query.Keyword))
            {
                colorQuery = colorQuery.Where(c => c.Name.Contains(query.Keyword)
                || c.UrlSlug.Contains(query.Keyword));
            }
            return colorQuery;
        } 

        public async Task<IPagedList<T>> GetPagedColorAsync<T>(ColorQuery query, 
            IPagingParams pagingParams, 
            Func<IQueryable<Color>, IQueryable<T>> mapper, 
            CancellationToken cancellationToken = default)
        {
            IQueryable<Color> colorResult = GetColorByQueryable(query);
            IQueryable<T> result = mapper(colorResult);
            return await result.ToPagedListAsync(pagingParams, cancellationToken);
        }

        public async Task<bool> IsColorExistBySlugAsync(
            int id,
            string slug,
            CancellationToken cancellationToken = default)
        {
            return await _context.Set<Color>()
                .AnyAsync(c => c.Id != id && c.UrlSlug == slug, cancellationToken);
        }
    }
}
