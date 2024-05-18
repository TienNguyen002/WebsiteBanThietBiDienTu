using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ISerieRepository
    {
        Task<IList<Serie>> GetAllSeries(); 
    }
}
