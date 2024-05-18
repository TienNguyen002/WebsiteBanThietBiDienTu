using Domain.DTO.Serie;

namespace Domain.Interfaces.Services
{
    public interface ISerieService
    {
       Task<IList<SeriesDTO>> GetAllSeries();
    }
}
