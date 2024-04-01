using Api.Response;
using Domain.DTO.Category;
using Domain.DTO.Status;
using Domain.Interfaces.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _service;
        private readonly ILogger<StatusController> _logger;
        private readonly IMapper _mapper;
        public StatusController(IStatusService service, ILogger<StatusController> logger,IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Statuses
        /// </summary>
        /// <returns> List Of Statuses </returns>
        [HttpGet("all")]
        public async Task<ActionResult<IList<StatusDTO>>> GetAllStatuses()
        {
            var statuses = await _service.GetAllStatuses();
            if (statuses == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(statuses));
        }
    }
}
