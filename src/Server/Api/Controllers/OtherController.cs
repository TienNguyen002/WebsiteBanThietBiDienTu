using Api.Response;
using Domain.DTO.Product;
using Domain.Interfaces.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherController : ControllerBase
    {
        private readonly IOtherService _service;
        private readonly ILogger<OtherController> _logger;
        private readonly IMapper _mapper;
        public OtherController(IOtherService service, ILogger<OtherController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("filter")]
        public async Task<ActionResult<ProductFilter>> GetProductFilters()
        {
            var result = await _service.GetProductFiltersAsync();
            return Ok(ApiResponse.Success(result));
        }
    }
}
