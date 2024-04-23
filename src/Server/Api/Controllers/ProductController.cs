using Api.Response;
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
            var branch = await _service.GetProductById(id);
            if (branch == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(branch));
        }

        /// <summary>
        /// Get Product By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get Product </param>
        /// <returns> Product With UrlSlug want to get </returns>
        [HttpGet("bySlug/{slug}")]
        public async Task<ActionResult<ProductDTO>> GetProductBySlug(string slug)
        {
            var branch = await _service.GetProductBySlug(slug);
            if (branch == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(branch));
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
            var branchCreate = await _service.AddOrUpdateProduct(model);
            if (!branchCreate)
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
    }
}
