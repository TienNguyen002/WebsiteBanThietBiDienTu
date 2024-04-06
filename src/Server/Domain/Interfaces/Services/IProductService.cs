using Domain.DTO.Product;

namespace Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<IList<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetProductById(int id);
        Task<ProductDTO> GetProductBySlug(string slug);
        Task<IList<ProductDTO>> GetProductByTag(string tag);
        Task<bool> AddOrUpdateProduct(ProductEditModel model);
        Task<bool> DeleteProduct(int id);
    }
}
