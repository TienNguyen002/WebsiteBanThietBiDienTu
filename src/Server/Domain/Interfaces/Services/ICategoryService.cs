using Domain.DTO.Category;

namespace Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<IList<CategoryDTO>> GetAllCategories();
        Task<CategoryDTO> GetCategoryById(int id);
        Task<CategoryDTO> GetCategoryBySlug(string slug);
        Task<bool> AddOrUpdateCategory(ColorEditModel model);
        Task<bool> DeleteCategory(int id);
    }
}
