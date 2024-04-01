using Domain.DTO.Category;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using MapsterMapper;
using SlugGenerator;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Add/Update By Find Category Id, If Id > 0 Update it by Model, else Create New Category By Model
        /// </summary>
        /// <param name="model"> Model to add/update </param>
        /// <returns> Added/Updated Category </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> AddOrUpdateCategory(CategoryEditModel model)
        {
            var category = model.Id > 0 ? await _repository.GetById(model.Id) : null;
            if (category == null)
            {
                category = new Category { };
            }
            category.Name = model.Name;
            category.UrlSlug = model.Name.GenerateSlug();
            await _repository.AddOrUpdateCategory(category);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Delete Category By Id
        /// </summary>
        /// <param name="id"> Id Of Category want to delete </param>
        /// <returns> Deleted Category </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteCategory(int id)
        {
            await _repository.DeleteCategory(id);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns> List Of Categories </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<CategoryDTO>> GetAllCategories()
        {
            var categories = await _repository.GetAllWithInclude(c => c.Products);
            return _mapper.Map<IList<CategoryDTO>>(categories);
        }

        /// <summary>
        /// Get Category By Id
        /// </summary>
        /// <param name="id"> Id Of Category want to get </param>
        /// <returns> Get Category By Id </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            var category = await _repository.GetByIdWithInclude(id, c => c.Products);
            return _mapper.Map<CategoryDTO>(category);
        }

        /// <summary>
        /// Get Category By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get Category </param>
        /// <returns> Category With UrlSlug want to get </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<CategoryDTO> GetCategoryBySlug(string slug)
        {
            var category = await _repository.GetCategoryBySlug(slug);
            return _mapper.Map<CategoryDTO>(category);
        }
    }
}
