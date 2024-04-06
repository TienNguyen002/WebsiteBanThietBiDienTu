using Api.Response;
using Domain.DTO.Tag;
using Domain.Interfaces.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService _service;
        private readonly ILogger<TagController> _logger;
        private readonly IMapper _mapper;
        public TagController(ITagService service, ILogger<TagController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Tags
        /// </summary>
        /// <returns> List Of Tags </returns>
        [HttpGet("all")]
        public async Task<ActionResult<IList<TagDTO>>> GetAllTags()
        {
            var tags = await _service.GetAllTags();
            if (tags == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(tags));
        }

        /// <summary>
        /// Get Tag By Id
        /// </summary>
        /// <param name="id"> Id Of Tag want to get </param>
        /// <returns> Get Tag By Id </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TagDTO>> GetTagById(int id)
        {
            var tag = await _service.GetTagById(id);
            if (tag == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(tag));
        }

        /// <summary>
        /// Get Tag By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get Tag </param>
        /// <returns> Tag With UrlSlug want to get </returns>
        [HttpGet("bySlug/{slug}")]
        public async Task<ActionResult<TagDTO>> GetTagBySlug(string slug)
        {
            var tag = await _service.GetTagBySlug(slug);
            if (tag == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(tag));
        }

        /// <summary>
        /// Add/Update Tag
        /// </summary>
        /// <param name="model"> Model to add/update </param>
        /// <returns> Added/Updated Tag </returns>
        [HttpPost]
        public async Task<ActionResult<TagDTO>> AddOrUpdateTag([FromForm] TagEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tagCreate = await _service.AddTag(model);
            if (!tagCreate)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest));
            }
            var result = _mapper.Map<TagDTO>(model);
            return Ok(ApiResponse.Success(result));
        }

        /// <summary>
        /// Delete Tag By Id
        /// </summary>
        /// <param name="id"> Id Of Tag want to delete </param>
        /// <returns> Delete Tag By Id </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTag(int id)
        {
            var result = await _service.DeleteTag(id);
            if (!result)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest));
            }
            return Ok(ApiResponse.Success(result)); ;
        }
    }
}
