using Api.Response;
using Domain.DTO.Category;
using Domain.DTO.Other;
using Domain.DTO.Product;
using Domain.Interfaces.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

        [HttpGet("allFeedback")]
        public async Task<ActionResult<FeedbackDTO>> GetAllFeedbacks()
        {
            var result = await _service.GetAllFeedbacks();
            return Ok(ApiResponse.Success(result));
        }

        [HttpPost("addFeedback")]
        public async Task<ActionResult<bool>> AddFeedback([FromForm] FeedbackEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var feedbackCreate = await _service.AddFeedback(model);
            if (!feedbackCreate)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest));
            }
            return Ok(ApiResponse.Success(feedbackCreate));
        }

        [HttpDelete("deleteFeedback/{id}")]
        public async Task<ActionResult> DeleteFeedback(int id)
        {
            var result = await _service.DeleteFeedback(id);
            if (!result)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest));
            }
            return Ok(ApiResponse.Success(result)); ;
        }
    }
}
