using Domain.DTO.Branch;
using Domain.DTO.Serie;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using MapsterMapper;

namespace Application.Services
{
    public class SerieService : ISerieService
    {
        private readonly ISerieRepository _repository;
        private readonly ICloundinaryService _cloundinaryService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SerieService(ISerieRepository repository, ICloundinaryService cloundinaryService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _cloundinaryService = cloundinaryService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<SeriesDTO>> GetAllSeries()
        {
            var series = await _repository.GetAllSeries();
            return _mapper.Map<IList<SeriesDTO>>(series);
        }
    }
}
