using Domain.DTO.Color;

namespace Domain.Interfaces.Services
{
    public interface IColorService
    {
        Task<IList<ColorDTO>> GetAllColors();
        Task<ColorDTO> GetColorById(int id);
        Task<ColorDTO> GetColorBySlug(string slug);
        Task<bool> AddOrUpdateColor(DiscountEditModel model);
        Task<bool> DeleteColor(int id);
    }
}
