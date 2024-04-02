using Domain.DTO.User;
using Domain.Interfaces.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
