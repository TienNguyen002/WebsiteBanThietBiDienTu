using Api.Response;
using Domain.DTO.Image;
using Domain.Interfaces.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _service;
        private readonly ILogger<ImageController> _logger;
        private readonly IMapper _mapper;
        public ImageController(IImageService service, ILogger<ImageController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Images
        /// </summary>
        /// <returns> List Of Images </returns>
        [HttpGet("all")]
        public async Task<ActionResult<IList<ImageDTO>>> GetAllImages()
        {
            var images = await _service.GetAllImages();
            if (images == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(images));
        }

        /// <summary>
        /// Get Image By Id
        /// </summary>
        /// <param name="id"> Id Of Image want to get </param>
        /// <returns> Get Image By Id </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageDTO>> GetImageById(int id)
        {
            var image = await _service.GetImageById(id);
            if (image == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(image));
        }

        /// <summary>
        /// Add/Update Image
        /// </summary>
        /// <param name="model"> Model to add/update </param>
        /// <returns> Added/Updated Image </returns>
        [HttpPost]
        public async Task<ActionResult<ImageDTO>> AddOrUpdateImage([FromForm] ImageEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageCreate = await _service.AddOrUpdateImage(model);
            if (!imageCreate)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest));
            }
            var result = _mapper.Map<ImageDTO>(model);
            return Ok(ApiResponse.Success(result));
        }

        /// <summary>
        /// Delete Image By Id
        /// </summary>
        /// <param name="id"> Id Of Image want to delete </param>
        /// <returns> Delete Image By Id </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteImage(int id)
        {
            var result = await _service.DeleteImage(id);
            if (!result)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest));
            }
            return Ok(ApiResponse.Success(result)); ;
        }
    }
}
