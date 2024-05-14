using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IList<Category>> GetAllCategories();
        Task<Category> GetCategoryBySlug(string slug);
        Task<bool> DeleteCategory(int id);
    }
}
