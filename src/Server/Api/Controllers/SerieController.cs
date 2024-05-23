using Api.Response;
using Domain.DTO.Category;
using Domain.DTO.Serie;
using Domain.Interfaces.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerieController : ControllerBase
    {
        private ISerieService _service;
        private readonly ILogger<SerieController> _logger;
        private readonly IMapper _mapper;
        public SerieController(ISerieService service, ILogger<SerieController> logger, IMapper mapper)
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
        public async Task<ActionResult<IList<SeriesDTO>>> GetAllSeries()
        {
            var series = await _service.GetAllSeries();
            if (series == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(series));
        }

        /// <summary>
        /// Get Serie By Slug
        /// </summary>
        /// <returns> List Of Categories </returns>
        [HttpGet("bySlug/{slug}")]
        public async Task<ActionResult<DetailSerieDTO>> GetSerieBySlug(string slug)
        {
            var serie = await _service.GetSerieBySlug(slug);
            if (serie == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(serie));
        }

        /// <summary>
        /// Get Serie By Slug
        /// </summary>
        /// <returns> List Of Categories </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DetailSerieDTO>> GetSerieById(int id)
        {
            var serie = await _service.GetSerieById(id);
            if (serie == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(serie));
        }

        /// <summary>
        /// Add/Update Category
        /// </summary>
        /// <param name="model"> Model to add/update </param>
        /// <returns> Added/Updated Category </returns>
        [HttpPost]
        public async Task<ActionResult<bool>> AddOrUpdateCategory([FromForm] SerieEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var serieCreate = await _service.AddOrUpdateSerie(model);
            if (!serieCreate)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest));
            }
            return Ok(ApiResponse.Success(serieCreate));
        }

        /// <summary>
        /// Delete Product By Id
        /// </summary>
        /// <param name="id"> Id Of Product want to delete </param>
        /// <returns> Delete Product By Id </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSerie(int id)
        {
            var result = await _service.DeleteSerie(id);
            if (!result)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest));
            }
            return Ok(ApiResponse.Success(result)); ;
        }
    }
}
