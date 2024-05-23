using Api.Response;
using Domain.DTO.Category;
using Domain.DTO.Order;
using Domain.DTO.OrderItem;
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

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> AddOrder([FromBody] OrderEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var orderCreate = await _service.AddOrder(model);
            if (!orderCreate)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest));
            }
            var result = _mapper.Map<OrderDTO>(model);
            return Ok(ApiResponse.Success(result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IList<OrderItemsDTO>>> GetOrderItemsByOrderIdAsync(int id)
        {
            var orders = await _service.GetOrderItemsByOrderIdAsync(id);
            if (orders == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(orders));
        }

        [HttpPut("moveNext/{id}")]
        public async Task<ActionResult<OrderDTO>> MoveNextStep(int id)
        {
            var order = await _service.MoveToNextStep(id);
            if (!order)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(order));
        }

        [HttpPut("cancel/{id}")]
        public async Task<ActionResult<OrderDTO>> CancelOrder(int id)
        {
            var order = await _service.CancelOrder(id);
            if (!order)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(order));
        }

        [HttpGet("byUser/{userId}")]
        public async Task<ActionResult<IList<OrderDTO>>> GetAllOrdersByUserId(string userId)
        {
            var orders = await _service.GetAllOrdersByUserId(userId);
            if (orders == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(orders));
        }
    }
}
