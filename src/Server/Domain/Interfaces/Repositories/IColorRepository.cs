using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IColorRepository : IGenericRepository<Color>
    {
        Task<Color> GetColorByName(string name);
        Task<bool> DeleteColor(int id);
    }
}
