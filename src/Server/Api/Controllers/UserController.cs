using Api.Response;
using Domain.DTO.Discount;
using Domain.DTO.User;
using Domain.Entities;
using Domain.Interfaces.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] UserRegisterDTO register)
        {
            var response = await _service.CreateAccount(register);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] UserLoginDTO login)
        {
            var response = await _service.LoginAccount(login);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(string id)
        {
            var user = await _service.GetUserById(id);
            if (user == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(user));
        }

        [HttpGet("all")]
        public async Task<ActionResult<IList<ListUserDTO>>> GetAllUsers()
        {
            var users = await _service.GetAllUsers();
            if (users == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(users));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] UserCreateDTO create)
        {
            var response = await _service.CreateAccountByAdmin(create);
            return Ok(ApiResponse.Success(response));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _service.DeleteAccount(id);
            return Ok(ApiResponse.Success(response));
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromForm] UserEditModel update)
        {
            var response = await _service.UpdateAccount(update);
            return Ok(ApiResponse.Success(response));
        }

        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePassword([FromForm] PasswordEditModel model)
        {
            var response = await _service.ChangePassword(model);
            return Ok(ApiResponse.Success(response));
        }

        [HttpPut("updateRole/{userId}")]
        public async Task<IActionResult> UpdateRole(string userId)
        {
            var response = await _service.UpdateRole(userId);
            return Ok(ApiResponse.Success(response));
        }
    }
}
