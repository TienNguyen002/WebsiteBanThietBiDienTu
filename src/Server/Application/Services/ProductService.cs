using Application.Media;
using Domain.Collections;
using Domain.Constants;
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
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediaManager _mediaManager;
        private readonly ICloundinaryService _cloundinaryService;
        public ProductService(IProductRepository repository, IColorRepository colorRepository, IMapper mapper, IUnitOfWork unitOfWork, IMediaManager mediaManager, ICloundinaryService cloundinaryService)
        {
            _repository = repository;
            _colorRepository = colorRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mediaManager = mediaManager;
            _cloundinaryService = cloundinaryService;
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
            product.ShortName = model.ShortName;
            product.UrlSlug = model.Name.GenerateSlug();
            if (model.ImageFile != null)
            {
                product.ImageUrl = await _cloundinaryService.UploadImageAsync(model.ImageFile.OpenReadStream(), model.ImageFile.FileName, QueryManagements.ProductFolder);
            }
            if (model.Colors != null)
            {
                foreach (var color in model.Colors)
                {
                    var dataColor = await _colorRepository.GetColorByName(color);
                    if (dataColor == null)
                    {
                        var newColor = new Color()
                        {
                            Name = color,
                            UrlSlug = color.GenerateSlug()
                        };
                        product.Colors.Add(newColor);
                    }
                    else
                    {
                        product.Colors.Add(dataColor);
                    }
                }
            }
            product.ShortDescription = model.ShortDescription;
            product.Specification = model.Specification;
            if (model.Price.HasValue)
            {
                product.Price = model.Price.Value;
            }
            product.OrPrice = model.OrPrice;
            product.SaleId = 1;
            product.SerieId = model.SerieId;
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
            var product = await _repository.GetByIdWithInclude(id, p => p.Colors);
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

        public async Task<bool> RemoveSaleProduct(int id)
        {
            var saleProduct = await _repository.GetSaleProductById(id);
            saleProduct.SalePrice = 0;
            saleProduct.SaleId = 1;
            await _repository.AddOrUpdate(saleProduct);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        public async Task<bool> AddToSaleProduct(SaleAddModel model)
        {
            var saleProduct = await _repository.GetByIdWithInclude(model.Id, p => p.Sale);
            saleProduct.SalePrice = model.SalePrice;
            saleProduct.SaleId = 2;
            await _repository.Update(saleProduct);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        public async Task<bool> AddMoreAmount(AmountAddModel model)
        {
            var product = await _repository.GetById(model.Id);
            product.Amount += model.Amount;
            await _repository.Update(product);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }
    }
}
