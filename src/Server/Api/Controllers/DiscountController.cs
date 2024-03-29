using Api.Response;
using Domain.DTO.Discount;
using Domain.Interfaces.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _service;
        private readonly ILogger<DiscountController> _logger;
        private readonly IMapper _mapper;
        public DiscountController(IDiscountService service, ILogger<DiscountController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Discounts
        /// </summary>
        /// <returns> List Of Discounts </returns>
        [HttpGet("all")]
        public async Task<ActionResult<IList<DiscountDTO>>> GetAllDiscounts()
        {
            var discounts = await _service.GetAllDiscounts();
            if(discounts == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(discounts));
        }

        /// <summary>
        /// Get Discount By Id
        /// </summary>
        /// <param name="id"> Id Of Discount want to get </param>
        /// <returns> Get Discount By Id </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DiscountDTO>> GetDiscountById(int id)
        {
            var discount = await _service.GetDiscountById(id);
            if (discount == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(discount));
        }

        /// <summary>
        /// Add Discount
        /// </summary>
        /// <param name="model"> Model to add </param>
        /// <returns> Added Discount </returns>
        [HttpPost]
        public async Task<ActionResult<DiscountDTO>> AddDiscount([FromForm] DiscountEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var discountCreate = await _service.AddDiscount(model);
            if (!discountCreate)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest));
            }
            var result = _mapper.Map<DiscountDTO>(model);
            return Ok(ApiResponse.Success(result));
        }

        /// <summary>
        /// Delete Discount By Id
        /// </summary>
        /// <param name="id"> Id Of Discount want to delete </param>
        /// <returns> Delete Discount By Id </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDiscount(int id)
        {
            var result = await _service.DeleteDiscount(id);
            if (!result)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest));
            }
            return Ok(ApiResponse.Success(result)); ;
        }
    }
}
