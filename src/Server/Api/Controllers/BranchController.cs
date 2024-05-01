using Api.Response;
using Domain.DTO.Branch;
using Domain.Interfaces.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _service;
        private readonly ILogger<BranchController> _logger;
        private readonly IMapper _mapper;
        public BranchController(IBranchService service, ILogger<BranchController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Branches
        /// </summary>
        /// <returns> List Of Branches </returns>
        [HttpGet("all")]
        public async Task<ActionResult<IList<BranchDTO>>> GetAllBranches()
        {
            var branches = await _service.GetAllBranches();
            if (branches == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(branches));
        }

        /// <summary>
        /// Get Branch By Id
        /// </summary>
        /// <param name="id"> Id Of Branch want to get </param>
        /// <returns> Get Branch By Id </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<BranchDTO>> GetBranchById(int id)
        {
            var branch = await _service.GetBranchById(id);
            if (branch == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(branch));
        }

        /// <summary>
        /// Get Branch By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get Branch </param>
        /// <returns> Branch With UrlSlug want to get </returns>
        [HttpGet("bySlug/{slug}")]
        public async Task<ActionResult<BranchDTO>> GetBranchBySlug(string slug)
        {
            var branch = await _service.GetBranchBySlug(slug);
            if (branch == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(branch));
        }

        /// <summary>
        /// Add/Update Branch
        /// </summary>
        /// <param name="model"> Model to add/update </param>
        /// <returns> Added/Updated Branch </returns>
        [HttpPost]
        public async Task<ActionResult<BranchDTO>> AddOrUpdateBranch([FromForm] BranchEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var branchCreate = await _service.AddOrUpdateBranch(model);
            if (!branchCreate)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest));
            }
            var result = _mapper.Map<BranchDTO>(model);
            return Ok(ApiResponse.Success(result));
        }

        /// <summary>
        /// Delete Branch By Id
        /// </summary>
        /// <param name="id"> Id Of Branch want to delete </param>
        /// <returns> Delete Branch By Id </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBranch(int id)
        {
            var result = await _service.DeleteBranch(id);
            if (!result)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest));
            }
            return Ok(ApiResponse.Success(result)); ;
        }

        [HttpGet("{limit}/{category}")]
        public async Task<ActionResult<BranchProductDTO>> GetLimitBranchByCategory(int limit, string category)
        {
            var branches = await _service.GetLimitBranchByCategory(limit, category);
            if (branches == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(branches));
        }
    }
}
