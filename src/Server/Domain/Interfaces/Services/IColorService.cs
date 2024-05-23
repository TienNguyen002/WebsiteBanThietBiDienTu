using Domain.DTO.Color;

namespace Domain.Interfaces.Services
{
    public interface IColorService
    {
        Task<IList<ColorDTO>> GetAllColors();
        Task<ColorDTO> GetColorById(int id);
        //Task<ColorDTO> GetColorBySlug(string slug);
        Task<bool> AddOrUpdateColor(ColorEditModel model);
        Task<bool> DeleteColor(int id);
    }
}
