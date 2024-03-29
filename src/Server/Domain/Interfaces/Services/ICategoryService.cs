using Domain.DTO.Category;

namespace Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<IList<ColorDTO>> GetAllCategories();
        Task<ColorDTO> GetCategoryById(int id);
        Task<ColorDTO> GetCategoryBySlug(string slug);
        Task<bool> AddOrUpdateCategory(ColorEditModel model);
        Task<bool> DeleteCategory(int id);
    }
}
