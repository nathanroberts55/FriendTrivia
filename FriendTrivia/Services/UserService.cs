using FriendTrivia.Data;
using FriendTrivia.Models;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;

namespace FriendTrivia.Services;

public interface IUserService
{
    Task<User?> GetUserAsync(string username);
}

public class UserService : IUserService
{
    private readonly IDbContextFactory<AppDbContext> _contextFactory;
    public UserService(IDbContextFactory<AppDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }
    public async Task<User?> GetUserAsync(string username)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        var user = await context.Users.FirstOrDefaultAsync(u => u.Username == username);

        if (user == null)
        {
            return null;
        }

        return user;
    }
}