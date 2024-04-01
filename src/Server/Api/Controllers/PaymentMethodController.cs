using Api.Response;
using Domain.DTO.PaymentMethod;
using Domain.Interfaces.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodService _service;
        private readonly ILogger<PaymentMethodController> _logger;
        private readonly IMapper _mapper;
        public PaymentMethodController(IPaymentMethodService service, ILogger<PaymentMethodController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Payment Methods
        /// </summary>
        /// <returns> List Of Payment Methods </returns>
        [HttpGet("all")]
        public async Task<ActionResult<IList<PaymentMethodDTO>>> GetAllPaymentMethods()
        {
            var paymentMethods = await _service.GetAllPaymentMethods();
            if (paymentMethods == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(paymentMethods));
        }

        /// <summary>
        /// Get Payment Method By Id
        /// </summary>
        /// <param name="id"> Id Of Payment Method want to get </param>
        /// <returns> Get Payment Method By Id </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentMethodDTO>> GetPaymentMethodById(int id)
        {
            var paymentMethod = await _service.GetPaymentMethodById(id);
            if (paymentMethod == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(paymentMethod));
        }

        /// <summary>
        /// Add Payment Method
        /// </summary>
        /// <param name="model"> Model to add </param>
        /// <returns> Added Payment Method </returns>
        [HttpPost]
        public async Task<ActionResult<PaymentMethodDTO>> AddPaymentMethod([FromForm] PaymentMethodEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var paymentMethodCreate = await _service.AddPaymentMethod(model);
            if (!paymentMethodCreate)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest));
            }
            var result = _mapper.Map<PaymentMethodDTO>(model);
            return Ok(ApiResponse.Success(result));
        }

        /// <summary>
        /// Delete Payment Method By Id
        /// </summary>
        /// <param name="id"> Id Of Payment Method want to delete </param>
        /// <returns> Delete Payment Method By Id </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePaymentMethod(int id)
        {
            var result = await _service.DeletePaymentMethod(id);
            if (!result)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest));
            }
            return Ok(ApiResponse.Success(result)); ;
        }
    }
}
