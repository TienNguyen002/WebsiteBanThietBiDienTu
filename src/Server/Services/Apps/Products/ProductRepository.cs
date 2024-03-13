using Core.Contracts;
using Core.DTO.Product;
using Core.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.Extensions;

namespace Services.Apps.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly WebDbContext _context;
        public ProductRepository(WebDbContext context)
        {
            _context = context;
        }

        public Task<bool> AddOrUpdateProductAsync(Product product, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteProduct(int id, CancellationToken cancellationToken = default)
        {
            var productDelete = await _context.Set<Product>()
                .Include(p => p.Trademark)
                .Include(p => p.Carts)
                .Include(p => p.Colors)
                .Include(p => p.Specifications)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
            if (productDelete == null)
            {
                return false;
            }
            _context.Remove(productDelete);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        private IQueryable<Product> GetProductByQueryable(ProductQuery query)
        {
            IQueryable<Product> productQuery = _context.Set<Product>()
                .Include(p => p.Trademark)
                .Include(p => p.Carts)
                .Include(p => p.Colors)
                .Include(p => p.Specifications);
            if(!string.IsNullOrEmpty(query.Keyword))
            {
                productQuery = productQuery.Where(p => p.Name.Contains(query.Keyword)
                || p.UrlSlug.Contains(query.Keyword));
            }
            if (!string.IsNullOrEmpty(query.CategorySlug))
            {
                productQuery = productQuery.Where(p => p.Category.UrlSlug.Contains(query.CategorySlug));
            }
            if (!string.IsNullOrEmpty(query.TrademarkSlug))
            {
                productQuery = productQuery.Where(p => p.Trademark.UrlSlug.Contains(query.TrademarkSlug));
            }
            if (!string.IsNullOrEmpty(query.Tag))
            {
                productQuery = productQuery.Where(p => p.Tag.Name.Contains(query.Tag)
                || p.Tag.UrlSlug.Contains(query.Tag));
            }
            return productQuery;
        }

        public async Task<IPagedList<T>> GetPagedProductAsync<T>(ProductQuery query, 
            IPagingParams pagingParams, 
            Func<IQueryable<Product>, IQueryable<T>> mapper, 
            CancellationToken cancellationToken = default)
        {
            IQueryable<Product> productResult = GetProductByQueryable(query);
            IQueryable<T> result = mapper(productResult);
            return await result.ToPagedListAsync(pagingParams, cancellationToken);
        }

        public async Task<Product> GetProductByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Product>()
                .Include(p => p.Trademark)
                .Include(p => p.Carts)
                .Include(p => p.Colors)
                .Include(p => p.Specifications)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Product> GetProductBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Product>()
               .Include(p => p.Trademark)
               .Include(p => p.Carts)
               .Include(p => p.Colors)
               .Include(p => p.Specifications)
               .Where(c => c.UrlSlug.Contains(slug))
               .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IList<ProductItems>> GetProductsByTagAsync(string tag, CancellationToken cancellationToken = default)
        {
            IQueryable<Product> products = _context.Set<Product>();
            return await products
                .OrderBy(p => p.Id)
                .Where(p => p.Tag.UrlSlug.Contains(tag))
                .Select(p => new ProductItems()
                {
                    Id = p.Id,
                    Name = p.Name,
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> IsProductExistBySlugAsync(int id, string slug, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Product>()
                .AnyAsync(c => c.Id != id && c.UrlSlug == slug, cancellationToken);
        }
    }
}
