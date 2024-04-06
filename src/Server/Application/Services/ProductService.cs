using Application.Media;
using Domain.DTO.Product;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using MapsterMapper;
using SlugGenerator;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediaManager _mediaManager;
        public ProductService(IProductRepository repository, IMapper mapper, IUnitOfWork unitOfWork, IMediaManager mediaManager)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mediaManager = mediaManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> AddOrUpdateProduct(ProductEditModel model)
        {
            var product = model.Id > 0 ? await _repository.GetById(model.Id) : null;
            if (product == null)
            {
                product = new Product { };
            }
            product.Name = model.Name;
            product.UrlSlug = model.Name.GenerateSlug();
            product.ImageUrl = await _mediaManager.SaveImgFileAsync(model.ImageFile.OpenReadStream(),
                                                                     model.ImageFile.FileName,
                                                                     model.ImageFile.ContentType);
            product.Description = model.Description;
            product.Specification = model.Specification;
            product.Amount = model.Amount;
            if(model.Amount > 0)
            {
                product.Status = true;
            }
            product.Price = model.Price;
            product.OrPrice = model.OrPrice;
            product.BranchId = model.BranchId;
            product.CategoryId = model.CategoryId;
            product.Tag.UrlSlug = model.TagSlug;
            await _repository.AddOrUpdate(product);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> DeleteProduct(int id)
        {
            await _repository.DeleteProduct(id);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IList<ProductDTO>> GetAllProducts()
        {
            var products = await _repository.GetAll();
            return _mapper.Map<IList<ProductDTO>>(products);    
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ProductDTO> GetProductById(int id)
        {
            var product = await _repository.GetById(id);
            return _mapper.Map<ProductDTO>(product);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ProductDTO> GetProductBySlug(string slug)
        {
            var product = await _repository.GetProductBySlug(slug);
            return _mapper.Map<ProductDTO>(product);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IList<ProductDTO>> GetProductByTag(string tag)
        {
            var products = await _repository.GetAllProductByTag(tag);
            return _mapper.Map<IList<ProductDTO>>(products);
        }
    }
}
