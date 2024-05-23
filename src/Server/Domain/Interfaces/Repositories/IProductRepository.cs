using Domain.Contracts;
using Domain.DTO.Product;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<bool> DeleteProduct(int id);
        //Task<IList<Product>> GetAllProductByTag(string tag);
        Task<IList<Product>> GetTopProducts(int limit);
        Task<IList<Product>> GetNewProducts(int limit);
        Task<IList<Product>> GetSoldProducts(int limit);
        Task<IList<Product>> GetLimitProductByCategory(int limit, string category);
        Task<IPagedList<Product>> GetPagedProductAsync(ProductQuery query,
            IPagingParams pagingParams);
        Task<ProductFilter> GetProductFiltersAsync(FilterQuery query);
        Task<Product> GetProductBySlug(string slug);
        Task<Product> GetSaleProductById(int id);
    }
}
