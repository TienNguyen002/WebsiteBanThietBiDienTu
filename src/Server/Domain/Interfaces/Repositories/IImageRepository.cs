using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IImageRepository : IGenericRepository<Image>
    {
        Task<bool> DeleteImage(int id);
    }
}
