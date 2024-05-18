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
    }
}
