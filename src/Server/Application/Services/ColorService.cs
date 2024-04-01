using Domain.DTO.Category;
using Domain.DTO.Color;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using MapsterMapper;
using SlugGenerator;

namespace Application.Services
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ColorService(IColorRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Add/Update By Find Color Id, If Id > 0 Update it by Model, else Create New Color By Model
        /// </summary>
        /// <param name="model"> Model to add/update </param>
        /// <returns> Added/Updated Color </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> AddOrUpdateColor(ColorEditModel model)
        {
            var color = model.Id > 0 ? await _repository.GetById(model.Id) : null;
            if (color == null)
            {
                color = new Color { };
            }
            color.Name = model.Name;
            color.UrlSlug = model.Name.GenerateSlug();
            await _repository.AddOrUpdateColor(color);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Delete Color By Id
        /// </summary>
        /// <param name="id"> Id Of Color want to delete </param>
        /// <returns> Deleted Color </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteColor(int id)
        {
            await _repository.DeleteColor(id);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Get All Colors
        /// </summary>
        /// <returns> List Of Colors </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<ColorDTO>> GetAllColors()
        {
            var colors = await _repository.GetAllWithInclude(c => c.Products);
            return _mapper.Map<IList<ColorDTO>>(colors);
        }

        /// <summary>
        /// Get Color By Id
        /// </summary>
        /// <param name="id"> Id Of Color want to get </param>
        /// <returns> Get Color By Id </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ColorDTO> GetColorById(int id)
        {
            var color = await _repository.GetByIdWithInclude(id, c => c.Products);
            return _mapper.Map<ColorDTO>(color);
        }

        /// <summary>
        /// Get Color By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get Color </param>
        /// <returns> Color With UrlSlug want to get </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ColorDTO> GetColorBySlug(string slug)
        {
            var color = await _repository.GetColorBySlug(slug);
            return _mapper.Map<ColorDTO>(color);
        }
    }
}
