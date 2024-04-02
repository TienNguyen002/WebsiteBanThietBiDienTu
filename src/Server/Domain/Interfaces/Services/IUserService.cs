using Domain.DTO.User;
using static Api.Response.ServiceResponses;

namespace Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<GeneralResponse> CreateAccount(UserRegisterDTO register);
        Task<LoginResponse> LoginAccount(UserLoginDTO login);
    }
}
