using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ISerieRepository : IGenericRepository<Serie>   
    {
        Task<IList<Serie>> GetAllSeries();
        Task<Serie> GetSerieById(int id);
        Task<Serie> GetSerieByProductSlug(string slug);
        Task<Serie> GetSerieBySlug(string slug);
        Task<bool> DeleteSerie(int id);
    }
}
