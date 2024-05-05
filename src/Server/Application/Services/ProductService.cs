using Application.Media;
using Domain.Collections;
using Domain.DTO;
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
            product.Specification = model.Specification;
            product.Amount = model.Amount;
            product.Price = model.Price;
            product.OrPrice = model.OrPrice;
            //product.BranchId = model.BranchId;
            //product.CategoryId = model.CategoryId;
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

        public async Task<IList<ProductByCategoryDTO>> GetLimitProductByCategory(int limit, string category)
        {
            var products = await _repository.GetLimitProductByCategory(limit, category);
            return _mapper.Map<IList<ProductByCategoryDTO>>(products);
        }

        public async Task<IList<ProductDTO>> GetNewProducts(int limit)
        {
            var products = await _repository.GetNewProducts(limit);
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
        public async Task<ProductDetailDTO> GetProductBySlug(string slug)
        {
            var product = await _repository.GetProductBySlug(slug);
            return _mapper.Map<ProductDetailDTO>(product);
        }

        public async Task<IList<ProductDTO>> GetSoldProducts(int limit)
        {
            var products = await _repository.GetSoldProducts(limit);
            return _mapper.Map<IList<ProductDTO>>(products);
        }

        public async Task<IList<ProductDTO>> GetTopProducts(int limit)
        {
            var products = await _repository.GetTopProducts(limit);
            return _mapper.Map<IList<ProductDTO>>(products);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        //public async Task<IList<ProductDTO>> GetProductByTag(string tag)
        //{
        //    var products = await _repository.GetAllProductByTag(tag);
        //    return _mapper.Map<IList<ProductDTO>>(products);
        //}

        public async Task<PaginationResult<ProductDTO>> GetPagedProductsAsync(ProductQuery query,
            PagingModel pagingModel)
        {
            var result = await _repository.GetPagedProductAsync(query, pagingModel);
            var products = _mapper.Map<List<Product>, List<ProductDTO>>(result.ToList());
            var paginationResult = new PaginationResult<ProductDTO>(new PagedList<ProductDTO>(products, result.PageNumber, result.PageSize, result.TotalItemCount));
            return paginationResult;
        }

        public async Task<ProductFilter> GetProductFiltersAsync(FilterQuery query)
        {
            return await _repository.GetProductFiltersAsync(query);
        }
    }
}
