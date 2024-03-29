using Api.Response;
using Domain.DTO.Color;
using Domain.Interfaces.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _service;
        private readonly ILogger<ColorController> _logger;
        private readonly IMapper _mapper;
        public ColorController(IColorService service, ILogger<ColorController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Colors
        /// </summary>
        /// <returns> List Of Colors </returns>
        [HttpGet("all")]
        public async Task<ActionResult<IList<ColorDTO>>> GetAllColors()
        {
            var colors = await _service.GetAllColors();
            if(colors == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(colors));
        }

        /// <summary>
        /// Get Color By Id
        /// </summary>
        /// <param name="id"> Id Of Color want to get </param>
        /// <returns> Get Color By Id </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ColorDTO>> GetColorById(int id)
        {
            var color = await _service.GetColorById(id);
            if (color == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(color));
        }

        /// <summary>
        /// Get Color By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get Color </param>
        /// <returns> Color With UrlSlug want to get </returns>
        [HttpGet("bySlug/{slug}")]
        public async Task<ActionResult<ColorDTO>> GetColorBySlug(string slug)
        {
            var color = await _service.GetColorBySlug(slug);
            if (color == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(color));
        }

        /// <summary>
        /// Add/Update Color
        /// </summary>
        /// <param name="model"> Model to add/update </param>
        /// <returns> Added/Updated Color </returns>
        [HttpPost]
        public async Task<ActionResult<ColorDTO>> AddOrUpdateColor([FromForm] DiscountEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var colorCreate = await _service.AddOrUpdateColor(model);
            if (!colorCreate)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest));
            }
            var result = _mapper.Map<ColorDTO>(model);
            return Ok(ApiResponse.Success(result));
        }

        /// <summary>
        /// Delete Color By Id
        /// </summary>
        /// <param name="id"> Id Of Color want to delete </param>
        /// <returns> Delete Color By Id </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteColor(int id)
        {
            var result = await _service.DeleteColor(id);
            if (!result)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest));
            }
            return Ok(ApiResponse.Success(result)); ;
        }
    }
}
