using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> GetProductBySlug(string slug);
        //Task<IList<Product>> GetAllProductByTag(string tag);
        Task<bool> DeleteProduct(int id);
    }
}
