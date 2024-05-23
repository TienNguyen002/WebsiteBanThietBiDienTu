using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IList<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        Task<Category> GetCategoryBySlug(string slug);
        Task<bool> DeleteCategory(int id);
    }
}
