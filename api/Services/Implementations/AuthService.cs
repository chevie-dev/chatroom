using api.Exceptions;
using api.Models.Auth;
using api.Repositories.Implementations;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace api.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly PasswordHasher<User> _hasher = new();
    private readonly UserRepository _user;

    public AuthService(UserRepository user)
    {
        this._user = user;
    }

    public async Task Register(UserRegisterRequest request)
    {
        if (await _user.IsUserTaken(request.Username))
        {
            throw new UsernameTakenException(request.Username);
        }

        var user = new User { Username = request.Username };
        user.PasswordHash = _hasher.HashPassword(user, request.Password);

        await _user.AddUser(user);
    }

    public async Task<User> Login(UserLoginRequest request)
    {
        var user = await _user.GetUser(request.Username);
        if (user is null)
        {
            throw new InvalidCredentialsException();
        }
        

        var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            throw new InvalidCredentialsException();
        }

        return user;
    }
}
