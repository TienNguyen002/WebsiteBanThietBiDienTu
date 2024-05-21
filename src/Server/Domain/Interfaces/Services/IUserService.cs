using Domain.DTO.User;
using static Api.Response.ServiceResponses;

namespace Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetUserById(string id);   
        Task<GeneralResponse> CreateAccount(UserRegisterDTO register);
        Task<GeneralResponse> CreateAccountByAdmin(UserCreateDTO register);
        Task<LoginResponse> LoginAccount(UserLoginDTO login);
        Task<IList<ListUserDTO>> GetAllUsers();
        Task<GeneralResponse> DeleteAccount(string userId);
        Task<GeneralResponse> UpdateAccount(UserEditModel model);
        Task<GeneralResponse> ChangePassword(PasswordEditModel model);
        Task<GeneralResponse> UpdateRole(string userId);
    }
}
