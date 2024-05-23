using Domain.DTO.Image;

namespace Domain.Interfaces.Services
{
    public interface IImageService
    {
        Task<IList<ImageDTO>> GetAllImages();
        Task<ImageDTO> GetImageById(int id);
        Task<bool> AddOrUpdateImage(ImageEditModel model);
        Task<bool> DeleteImage(int id);
    }
}
