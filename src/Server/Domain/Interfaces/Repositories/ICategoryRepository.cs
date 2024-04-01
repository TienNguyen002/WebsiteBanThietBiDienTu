using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetCategoryBySlug(string slug);
        Task<bool> AddOrUpdateCategory(Category category);
        Task<bool> DeleteCategory(int id);
    }
}
