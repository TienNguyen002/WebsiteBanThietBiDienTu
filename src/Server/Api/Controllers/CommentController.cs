using Api.Response;
using Domain.DTO.Comment;
using Domain.Interfaces.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _service;
        private readonly ILogger<CommentController> _logger;
        private readonly IMapper _mapper;
        public CommentController(ICommentService service, ILogger<CommentController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Add/Update Comment
        /// </summary>
        /// <param name="model"> Model to add/update </param>
        /// <returns> Added/Updated Comment </returns>
        [HttpPost]
        public async Task<ActionResult<CommentDTO>> AddOrUpdateComment([FromForm] CommentEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commentCreate = await _service.AddComment(model);
            if (!commentCreate)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest));
            }
            var result = _mapper.Map<CommentDTO>(model);
            return Ok(ApiResponse.Success(result));
        }

        /// <summary>
        /// Get All Commentes
        /// </summary>
        /// <returns> List Of Commentes </returns>
        [HttpGet("getByProductSlug/{slug}")]
        public async Task<ActionResult<IList<CommentDTO>>> GetAllCommentes(string slug)
        {
            var comments = await _service.GetCommentsByProductSlug(slug);
            if (comments == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(comments));
        }

        [HttpGet("count/{slug}")]
        public async Task<ActionResult<IList<CommentCountDTO>>> CountAllComments(string slug)
        {
            var comments = await _service.CountAllComment(slug);
            if (comments == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(comments));
        }
    }
}
