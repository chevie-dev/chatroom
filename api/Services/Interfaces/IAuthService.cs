using api.Models.Auth;

namespace api.Services.Interfaces;

public interface IAuthService
{
    Task Register(UserRegisterRequest request);
    Task<User> Login(UserLoginRequest request);
}
