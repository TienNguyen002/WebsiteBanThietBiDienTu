    using Domain.Constants;
using Domain.DTO.Branch;
using Domain.DTO.Serie;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using MapsterMapper;
using SlugGenerator;

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

        public async Task<bool> AddOrUpdateSerie(SerieEditModel model)
        {
            var serie = model.Id > 0 ? await _repository.GetByIdWithInclude(model.Id, s => s.Images) : null;
            if (serie == null)
            {
                serie = new Serie { };
            }
            serie.Name = model.Name;
            serie.UrlSlug = model.Name.GenerateSlug();
            serie.Description = model.Description;
            serie.CategoryId = model.CategoryId;
            serie.BranchId = model.BranchId;
            if (model.Images != null)
            {
                if (serie.Images != null)
                {
                    serie.Images.Clear();
                }
                foreach (var imageModel in model.Images)
                {
                    var newImage = new Image()
                    {
                        ImageUrl = imageModel
                    };
                    serie.Images.Add(newImage);
                }
            }
            if (model.Images == null)
            {
                if (serie.Images != null)
                {
                    serie.Images.Clear();
                }
            }
            await _repository.AddOrUpdate(serie);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        public async Task<bool> DeleteSerie(int id)
        {
            await _repository.DeleteSerie(id);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        public async Task<IList<SeriesDTO>> GetAllSeries()
        {
            var series = await _repository.GetAllSeries();
            return _mapper.Map<IList<SeriesDTO>>(series);
        }

        public async Task<SerieDTO> GetSerieById(int id)
        {
            var serie = await _repository.GetSerieById(id);
            return _mapper.Map<SerieDTO>(serie);
        }

        public async Task<DetailSerieDTO> GetSerieBySlug(string slug)
        {
            var serie = await _repository.GetSerieBySlug(slug);
            return _mapper.Map<DetailSerieDTO>(serie);  
        }
    }
}
