using Api.Response;
using Domain.DTO.Category;
using Domain.Interfaces.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly ILogger<CategoryController> _logger;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService service, ILogger<CategoryController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns> List Of Categories </returns>
        [HttpGet("all")]
        public async Task<ActionResult<IList<ColorDTO>>> GetAllCategories()
        {
            var categories = await _service.GetAllCategories();
            if(categories == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(categories));
        }

        /// <summary>
        /// Get Category By Id
        /// </summary>
        /// <param name="id"> Id Of Category want to get </param>
        /// <returns> Get Category By Id </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ColorDTO>> GetCategoryById(int id)
        {
            var category = await _service.GetCategoryById(id);
            if (category == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(category));
        }

        /// <summary>
        /// Get Category By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get Category </param>
        /// <returns> Category With UrlSlug want to get </returns>
        [HttpGet("bySlug/{slug}")]
        public async Task<ActionResult<ColorDTO>> GetCategoryBySlug(string slug)
        {
            var category = await _service.GetCategoryBySlug(slug);
            if (category == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(category));
        }

        /// <summary>
        /// Add/Update Category
        /// </summary>
        /// <param name="model"> Model to add/update </param>
        /// <returns> Added/Updated Category </returns>
        [HttpPost]
        public async Task<ActionResult<ColorDTO>> AddOrUpdateCategory([FromForm] ColorEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoryCreate = await _service.AddOrUpdateCategory(model);
            if (!categoryCreate)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest));
            }
            var result = _mapper.Map<ColorDTO>(model);
            return Ok(ApiResponse.Success(result));
        }

        /// <summary>
        /// Delete Category By Id
        /// </summary>
        /// <param name="id"> Id Of Category want to delete </param>
        /// <returns> Delete Category By Id </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var result = await _service.DeleteCategory(id);
            if (!result)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest));
            }
            return Ok(ApiResponse.Success(result)); ;
        }
    }
}
