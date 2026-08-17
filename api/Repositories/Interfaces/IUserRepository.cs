using api.Models.Auth;
using Microsoft.Identity.Client;

namespace api.Repositories.Interfaces;

public interface IUserRepository
{
    Task AddUser(User user);
    Task<User> GetUser(string username);
    Task<bool> IsUserTaken(string username);
}
