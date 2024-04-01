using Domain.DTO.Tag;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using MapsterMapper;
using SlugGenerator;

namespace Application.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public TagService(ITagRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Add Tag
        /// </summary>
        /// <param name="model"> Model to add </param>
        /// <returns> Added Tag </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> AddTag(TagEditModel model)
        {
            var tag = model.Id > 0 ? await _repository.GetById(model.Id) : null;
            if (tag == null)
            {
                tag = new Tag { };
            }
            tag.Name = model.Name;
            tag.UrlSlug = model.Name.GenerateSlug();
            await _repository.AddTag(tag);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Delete Tag By Id
        /// </summary>
        /// <param name="id"> Id Of Tag want to delete </param>
        /// <returns> Deleted Tag </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteTag(int id)
        {
            await _repository.DeleteTag(id);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Get All Tags
        /// </summary>
        /// <returns> List Of Tags </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<TagDTO>> GetAllTags()
        {
            var tags = await _repository.GetAllWithInclude(b => b.Products);
            return _mapper.Map<IList<TagDTO>>(tags);
        }

        /// <summary>
        /// Get Tag By Id
        /// </summary>
        /// <param name="id"> Id Of Tag want to get </param>
        /// <returns> Get Tag By Id </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<TagDTO> GetTagById(int id)
        {
            var tag = await _repository.GetByIdWithInclude(id, b => b.Products);
            return _mapper.Map<TagDTO>(tag);
        }

        /// <summary>
        /// Get Tag By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get Tag </param>
        /// <returns> Tag With UrlSlug want to get </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<TagDTO> GetTagBySlug(string slug)
        {
            var tag = await _repository.GetTagBySlug(slug);
            return _mapper.Map<TagDTO>(tag);
        }
    }
}
