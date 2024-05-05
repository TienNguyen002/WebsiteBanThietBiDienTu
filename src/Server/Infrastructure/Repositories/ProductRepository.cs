using Domain.Contracts;
using Domain.DTO.Branch;
using Domain.DTO.Category;
using Domain.DTO.Color;
using Domain.DTO.Product;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DeviceWebDbContext context) : base(context) { }

        /// <summary>
        /// Delete Product By Id
        /// </summary>
        /// <param name="id">Id of product want to delete</param>
        /// <returns>Deleted Product</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteProduct(int id)
        {
            var productToDelete = await _context.Set<Product>()
                .Include(p => p.Serie)
                .Include(p => p.Colors)
                .Include(p => p.Sale)
                .Include(p => p.OrderItems)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            try
            {
                _context.Remove(productToDelete);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IList<Product>> GetLimitProductByCategory(int limit, string category)
        {
            return await _context.Set<Product>()
                .Include(p => p.Serie)
                .Include(p => p.Colors)
                .Where(p => p.Serie.Category.UrlSlug.Contains(category))
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IList<Product>> GetNewProducts(int limit)
        {
            return await _context.Set<Product>()
               .Include(p => p.Colors)
               .OrderByDescending(p => p.Id)
               .Take(limit)
               .ToListAsync();
        }

        /// <summary>
        /// Get All Product By Tag
        /// </summary>
        /// <param name="tag">Tag of product want to get</param>
        /// <returns>A list of product getting by tag</returns>
        /// <exception cref="ArgumentNullException"></exception>
        //public async Task<IList<Product>> GetAllProductByTag(string tag)
        //{
        //    return await _context.Set<Product>()
        //        .Where(p => p.Tag.UrlSlug.Contains(tag))
        //        .ToListAsync();
        //}

        public async Task<Product> GetProductBySlug(string slug)
        {
            return await _context.Set<Product>()
                .Include(p => p.Serie)
                    .ThenInclude(s => s.Comments)
                .Include(p => p.Serie)
                    .ThenInclude(s => s.Images)
                .Include(p => p.Serie)
                    .ThenInclude(s => s.Branch)
                .Include(s => s.Colors)
                 .Include(p => p.Serie)
                    .ThenInclude(s => s.Category)
                 .Include(p => p.Serie)
                    .ThenInclude(s => s.Products)
                .Where(p => p.UrlSlug.Contains(slug))
                .FirstOrDefaultAsync();
        }

        public async Task<IList<Product>> GetSoldProducts(int limit)
        {
            return await _context.Set<Product>()
               .Include(p => p.Colors)
               .OrderBy(p => p.SoldQuantity)
               .Take(limit)
               .ToListAsync();
        }

        public async Task<IList<Product>> GetTopProducts(int limit)
        {
            return await _context.Set<Product>()
               .Include(p => p.Colors)
               .OrderBy(p => p.Rating)
               .Take(limit)
               .ToListAsync();
        }

        private IQueryable<Product> GetProductByQueryable(ProductQuery query)
        {
            IQueryable<Product> productQuery = _context.Set<Product>()
                .Include(p => p.Sale)
                .Include(p => p.Serie)
                    .ThenInclude(p => p.Category)
                .Include(p => p.Serie)
                    .ThenInclude(p => p.Branch)
                .Include(p => p.Colors);
            if (query.IsSale)
            {
                productQuery = productQuery.Where(i => i.Sale.Status == query.IsSale);
            }
            if (query.IsHighRating)
            {
                productQuery = productQuery.Where(i => i.Rating >= 4).OrderBy(p => p.Rating);
            }
            if (query.IsNew)
            {
                productQuery = productQuery.Where(i => i.Rating == null).OrderByDescending(p => p.Id);
            }
            if (query.IsTop)
            {
                productQuery = productQuery.OrderBy(p => p.SoldQuantity);
            }
            if (query.Rating == 0 || string.IsNullOrWhiteSpace(query.Category) || string.IsNullOrWhiteSpace(query.Branch) || string.IsNullOrWhiteSpace(query.Color))
            {
                productQuery = productQuery.OrderByDescending(p => p.Id);
            }
            if (!string.IsNullOrWhiteSpace(query.Category))
            {
                productQuery = productQuery.Where(p => p.Serie.Category.UrlSlug == query.Category);
            }
            if (!string.IsNullOrWhiteSpace(query.Branch))
            {
                productQuery = productQuery.Where(p => p.Serie.Branch.UrlSlug == query.Branch);
            }
            if (!string.IsNullOrWhiteSpace(query.SortOrder))
            {
                switch (query.SortOrder.ToUpper())
                {
                    case "ASC":
                        productQuery = productQuery.OrderBy(p => p.Name);
                        break;
                    case "DESC":
                        productQuery = productQuery.OrderByDescending(p => p.Name);
                        break;
                    case "HighPrice":
                        productQuery = productQuery.OrderByDescending(p => (int?)p.Price ?? (int?)p.OrPrice);
                        break;
                    case "LowPrice":
                        productQuery = productQuery.OrderBy(p => (int?)p.Price ?? (int?)p.OrPrice);
                        break;
                    default:
                        productQuery = productQuery.OrderByDescending(p => p.Id);
                        break;
                }
            }
            if (query.MinPrice > 0 && query.MaxPrice > 0)
            {
                productQuery = productQuery.Where(p =>
                    ((int?)p.Price ?? (int?)p.OrPrice) >= query.MinPrice &&
                    ((int?)p.Price ?? (int?)p.OrPrice) <= query.MaxPrice);
            }
            if (query.Rating > 0)
            {
                productQuery = productQuery.Where(p => p.Rating == query.Rating);
            }
            if (!string.IsNullOrWhiteSpace(query.Color))
            {
                productQuery = productQuery.Where(p => p.Colors.Any(c => c.Name.Contains(query.Color)));
            }
            return productQuery;
        }

        public async Task<IPagedList<Product>> GetPagedProductAsync(ProductQuery query,
            IPagingParams pagingParams)
        {
            var productQuery = GetProductByQueryable(query);
            var result = await productQuery.ToPagedListAsync(pagingParams);
            return result;
        }

        public async Task<ProductFilter> GetProductFiltersAsync(FilterQuery query)
        {
            IQueryable<Product> productQuery = _context.Set<Product>()
                .Include(p => p.Sale)
                .Include(p => p.Serie)
                    .ThenInclude(p => p.Category)
                .Include(p => p.Serie)
                    .ThenInclude(p => p.Branch)
                .Include(p => p.Colors);

            if (query.IsSale)
            {
                productQuery = productQuery.Where(i => i.Sale.Status == query.IsSale);
            }
            if (query.IsHighRating)
            {
                productQuery = productQuery.Where(i => i.Rating >= 4).OrderBy(p => p.Rating);
            }
            if (query.IsNew)
            {
                productQuery = productQuery.Where(i => i.Rating == null).OrderByDescending(p => p.Id);
            }
            if (query.IsTop)
            {
                productQuery = productQuery.OrderBy(p => p.SoldQuantity);
            }
            if (!string.IsNullOrWhiteSpace(query.Category))
            {
                productQuery = productQuery.Where(p => p.Serie.Category.UrlSlug.Contains(query.Category));
            }
            if (!string.IsNullOrWhiteSpace(query.Branch))
            {
                productQuery = productQuery.Where(p => p.Serie.Branch.UrlSlug.Contains(query.Branch));
            }
            var products = await productQuery.ToListAsync();
            var branches = products.Select(p => new BranchDTO
            {
                Id = p.Serie.Branch.Id,
                Name = p.Serie.Branch.Name,
                // Map other relevant properties
            })
           .DistinctBy(b => b.Id)
           .ToList();

            var categories = products.Select(p => new CategoryDTO
            {
                Id = p.Serie.Category.Id,
                Name = p.Serie.Category.Name,
                ImageUrl = p.Serie.Category.ImageUrl,
                UrlSlug = p.Serie.Category.UrlSlug,
                // Map other relevant properties
            })
           .DistinctBy(c => c.Id)
           .ToList();

            var colors = products.SelectMany(p => p.Colors)
              .Select(c => new ColorDTO
              {
                  Id = c.Id,
                  Name = c.Name,
                  // Map other relevant properties
              })
              .DistinctBy(c => c.Id)
              .ToList();

            return new ProductFilter
            {
                Branches = branches,
                Categories = categories,
                Colors = colors
            };
        }
    }
}
