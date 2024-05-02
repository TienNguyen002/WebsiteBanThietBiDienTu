using Domain.Collections;
using Domain.DTO;
using Domain.DTO.Product;

namespace Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<IList<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetProductById(int id);
        Task<ProductDetailDTO> GetProductBySlug(string slug);
        //Task<IList<ProductDTO>> GetProductByTag(string tag);
        Task<bool> AddOrUpdateProduct(ProductEditModel model);
        Task<bool> DeleteProduct(int id);
        Task<IList<ProductDTO>> GetTopProducts(int limit);
        Task<IList<ProductDTO>> GetNewProducts(int limit);
        Task<IList<ProductDTO>> GetSoldProducts(int limit);
        Task<IList<ProductByCategoryDTO>> GetLimitProductByCategory(int limit, string category);
        Task<ProductFilter> GetProductFiltersAsync(FilterQuery query);
        Task<PaginationResult<ProductDTO>> GetPagedProductsAsync(ProductQuery query, PagingModel pagingModel);
    }
}
