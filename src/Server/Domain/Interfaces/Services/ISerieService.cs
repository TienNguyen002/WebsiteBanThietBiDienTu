using Domain.DTO.Serie;

namespace Domain.Interfaces.Services
{
    public interface ISerieService
    {
       Task<IList<SeriesDTO>> GetAllSeries();
       Task<SerieDTO> GetSerieById(int id);
       Task<DetailSerieDTO> GetSerieBySlug(string slug);
       Task<bool> AddOrUpdateSerie(SerieEditModel model);
       Task<bool> DeleteSerie(int id);
    }
}
