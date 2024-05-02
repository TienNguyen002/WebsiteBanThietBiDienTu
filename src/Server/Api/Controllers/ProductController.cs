using Api.Response;
using Domain.DTO;
using Domain.DTO.Product;
using Domain.Interfaces.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;
        public ProductController(IProductService service, ILogger<ProductController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns> List Of Products </returns>
        [HttpGet("all")]
        public async Task<ActionResult<IList<ProductDTO>>> GetAllProducts()
        {
            var product = await _service.GetAllProducts();
            if (product == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(product));
        }

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns> List Of Products </returns>
        //[HttpGet("byTag/{tag}")]
        //public async Task<ActionResult<IList<ProductDTO>>> GetAllProductsByTag(string tag)
        //{
        //    var product = await _service.GetProductByTag(tag);
        //    if (product == null)
        //    {
        //        return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
        //    }
        //    return Ok(ApiResponse.Success(product));
        //}

        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <param name="id"> Id Of Product want to get </param>
        /// <returns> Get Product By Id </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var product = await _service.GetProductById(id);
            if (product == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(product));
        }

        /// <summary>
        /// Get Product By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get Product </param>
        /// <returns> Product With UrlSlug want to get </returns>
        [HttpGet("bySlug/{slug}")]
        public async Task<ActionResult<ProductDetailDTO>> GetProductBySlug(string slug)
        {
            var product = await _service.GetProductBySlug(slug);
            if (product == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(product));
        }

        /// <summary>
        /// Add/Update Product
        /// </summary>
        /// <param name="model"> Model to add/update </param>
        /// <returns> Added/Updated Product </returns>
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> AddOrUpdateProduct([FromForm] ProductEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productCreate = await _service.AddOrUpdateProduct(model);
            if (!productCreate)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest));
            }
            var result = _mapper.Map<ProductDTO>(model);
            return Ok(ApiResponse.Success(result));
        }

        /// <summary>
        /// Delete Product By Id
        /// </summary>
        /// <param name="id"> Id Of Product want to delete </param>
        /// <returns> Delete Product By Id </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var result = await _service.DeleteProduct(id);
            if (!result)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest));
            }
            return Ok(ApiResponse.Success(result)); ;
        }

        [HttpGet("top/{limit}")]
        public async Task<ActionResult<ProductDTO>> GetTopProducts(int limit)
        {
            var products = await _service.GetTopProducts(limit);
            if (products == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(products));
        }

        [HttpGet("new/{limit}")]
        public async Task<ActionResult<ProductDTO>> GetNewProducts(int limit)
        {
            var products = await _service.GetNewProducts(limit);
            if (products == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(products));
        }

        [HttpGet("sold/{limit}")]
        public async Task<ActionResult<ProductDTO>> GetSoldProducts(int limit)
        {
            var products = await _service.GetSoldProducts(limit);
            if (products == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(products));
        }

        [HttpGet("{limit}/{category}")]
        public async Task<ActionResult<ProductByCategoryDTO>> GetLimitProductByCategory(int limit, string category)
        {
            var products = await _service.GetLimitProductByCategory(limit, category);
            if (products == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(products));
        }

        [HttpGet("paged")]
        public async Task<ActionResult<ProductDTO>> GetPagedProduct([FromQuery] ProductQuery query,
           [FromQuery] PagingModel model)
        {
            var result = await _service.GetPagedProductsAsync(query, model);
            return Ok(ApiResponse.Success(result));
        }

        [HttpGet("filter")]
        public async Task<ActionResult<ProductFilter>> GetProductFilters([FromQuery] FilterQuery query)
        {
            var result = await _service.GetProductFiltersAsync(query);
            return Ok(ApiResponse.Success(result));
        }
    }
}
