using Domain.DTO.Order;
using Domain.DTO.User;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Infrastructure.Repositories;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Api.Response.ServiceResponses;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IUserRepository repository, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _repository = repository;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<GeneralResponse> CreateAccount(UserRegisterDTO register)
        {
            if (register is null) return new GeneralResponse(false, "Model is empty");
            var newUser = new ApplicationUser()
            {
                Name = register.Name,
                UserName = register.Email,
                Email = register.Email,
                PasswordHash = register.Password,
            };
            var user = await _userManager.FindByEmailAsync(newUser.Email);
            if (user is not null) return new GeneralResponse(false, "Email này đã được đăng ký");

            var createUser = await _userManager.CreateAsync(newUser!, register.Password);
            if (!createUser.Succeeded) return new GeneralResponse(false, "Đã có lỗi xảy ra, vui lòng thử lại");

            //Assign Default Role : Admin to first registrar; rest is user

            //if (checkAdmin is null)
            //{
            //    await roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
            //    await userManager.AddToRoleAsync(newUser, "Admin");
            //    return new GeneralResponse(true, "Account Created");
            //}

            var checkUser = await _roleManager.FindByNameAsync("Người dùng");
            if (checkUser is null)
                await _roleManager.CreateAsync(new IdentityRole() { Name = "Người dùng" });

            await _userManager.AddToRoleAsync(newUser, "Người dùng");
            return new GeneralResponse(true, "Tạo tài khoản thành công");
        }

        public async Task<GeneralResponse> CreateAccountByAdmin(UserCreateDTO register)
        {
            if (register is null) return new GeneralResponse(false, "Model is empty");
            var newUser = new ApplicationUser()
            {
                Name = register.Name,
                UserName = register.Email,
                Email = register.Email,
                PasswordHash = register.Password,
            };
            var user = await _userManager.FindByEmailAsync(newUser.Email);
            if (user is not null) return new GeneralResponse(false, "Email này đã được đăng ký");

            var createUser = await _userManager.CreateAsync(newUser!, register.Password);
            if (!createUser.Succeeded) return new GeneralResponse(false, "Đã có lỗi xảy ra, vui lòng thử lại");

            //Assign Default Role : Admin to first registrar; rest is user

            //if (checkAdmin is null)
            //{
            //    await roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
            //    await userManager.AddToRoleAsync(newUser, "Admin");
            //    return new GeneralResponse(true, "Account Created");
            //}

            var checkUser = await _roleManager.FindByNameAsync("Nhân viên");
            if (checkUser is null)
                await _roleManager.CreateAsync(new IdentityRole() { Name = "Nhân viên" });

            await _userManager.AddToRoleAsync(newUser, "Nhân viên");
            return new GeneralResponse(true, "Tạo tài khoản thành công");
        }

        public async Task<IList<ListUserDTO>> GetAllUsers()
        {
            var users = await _repository.GetAllUsers();

            var usersWithRolesAndOrders = new List<ListUserDTO>();

            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var userOrders = await _repository.GetOrdersByUserIdAsync(user.Id);

                var userWithRolesAndOrders = new ListUserDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Address = user.Address,
                    PhoneNumber = user.PhoneNumber,
                    Role = userRoles.First(),
                    Orders = _mapper.Map<IList<OrderDTO>>(userOrders)
                };

                usersWithRolesAndOrders.Add(userWithRolesAndOrders);
            }
            return usersWithRolesAndOrders;
        }

        public async Task<UserDTO> GetUserById(string id)
        {
            var getUser = await _userManager.FindByIdAsync(id);
            return _mapper.Map<UserDTO>(getUser);
        }

        public async Task<GeneralResponse> DeleteAccount(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return new GeneralResponse(false, "Không tìm thấy người dùng");

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                return new GeneralResponse(false, "Đã xảy ra lỗi khi xóa tài khoản");
            return new GeneralResponse(true, "Đã xóa tài khoản!");
        }

        public async Task<GeneralResponse> UpdateAccount(UserEditModel model)
        {
            if (model == null)
                return new GeneralResponse(false, "Thông tin không được bỏ trống");

            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
                return new GeneralResponse(false, "Không tìm thấy người dùng");

            user.Name = model.Name;
            user.Email = model.Email;
            user.Address = model.Address;
            user.PhoneNumber = model.Phone;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return new GeneralResponse(false, "Đã xảy ra lỗi khi cập nhật thông tin");

            return new GeneralResponse(true, "Đã cập nhật thông tin!");
        }

        public async Task<GeneralResponse> ChangePassword(PasswordEditModel model)
        {
            if (model == null)
                return new GeneralResponse(false, "Thông tin không được bỏ trống");

            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
                return new GeneralResponse(false, "Không tìm thấy người dùng");

            if (!await _userManager.CheckPasswordAsync(user, model.OldPassword))
                return new GeneralResponse(false, "Mật khẩu cũ không chính xác");

            user.PasswordHash = model.Password;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return new GeneralResponse(false, "Đã xảy ra lỗi khi cập nhật thông tin");

            return new GeneralResponse(true, "Đã cập nhật thông tin!");
        }

        public async Task<GeneralResponse> UpdateRole(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return new GeneralResponse(false, "Không tìm thấy người dùng");

            var currentRole = await _userManager.GetRolesAsync(user);
            if (currentRole.Contains("Nhân viên"))
            {
                await _userManager.RemoveFromRoleAsync(user, "Nhân viên");
                await _userManager.AddToRoleAsync(user, "Quản lý");
            }
            if (currentRole.Contains("Người dùng"))
            {
                await _userManager.RemoveFromRoleAsync(user, "Người dùng");
                await _userManager.AddToRoleAsync(user, "Nhân viên");
            }

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return new GeneralResponse(false, "Đã xảy ra lỗi khi cập nhật thông tin");

            return new GeneralResponse(true, "Đã cập nhật thông tin!");
        }

        public async Task<LoginResponse> LoginAccount(UserLoginDTO login)
        {
            if (login == null)
                return new LoginResponse(false, null!, "Thiếu thông tin");

            var getUser = await _userManager.FindByEmailAsync(login.Email);
            if (getUser is null)
                return new LoginResponse(false, null!, "Không tìm thấy tài khoản");

            bool checkUserPasswords = await _userManager.CheckPasswordAsync(getUser, login.Password);
            if (!checkUserPasswords)
                return new LoginResponse(false, null!, "Sai email hoặc mật khẩu");

            var getUserRole = await _userManager.GetRolesAsync(getUser);
            var userSession = new UserSession(getUser.Id, getUser.Name, getUser.Email, getUserRole.First());
            string token = GenerateToken(userSession);
            return new LoginResponse(true, token!, "Đăng nhập thành công");
        }

        private string GenerateToken(UserSession user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
