using Api.Response;
using Domain.DTO.Order;
using Domain.DTO.Serie;
using Domain.Interfaces.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _service;
        private readonly ILogger<OrderController> _logger;
        private readonly IMapper _mapper;
        public OrderController(IOrderService service, ILogger<OrderController> logger, IMapper mapper)
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
        public async Task<ActionResult<IList<OrderDTO>>> GetAllOrders()
        {
            var orders = await _service.GetAllOrders();
            if (orders == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(orders));
        }
    }
}
