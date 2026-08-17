using api.Data;
using api.Models.Auth;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;

    public UserRepository(AppDbContext db)
    {
        this._db = db;
    }

    public async Task AddUser(User user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
    }

    public Task<User> GetUser(string username)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsUserTaken(string username)
    {
        if (await _db.Users.AnyAsync(u => u.Username == username))
        {
            return true;
        }

        return false;
    }
}
