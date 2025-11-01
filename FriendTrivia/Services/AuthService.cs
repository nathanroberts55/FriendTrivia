using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using FriendTrivia.Models;
using Microsoft.EntityFrameworkCore;
using FriendTrivia.Data;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;

namespace FriendTrivia.Services;

public interface IAuthService
{
    Task<User?> RegisterAsync(string username, string password);
    Task<User?> LoginAsync(string username, string password);
    string HashPassword(string password);
    bool VerifyPassword(string password, string hash);
}

public class AuthService : IAuthService
{
    private readonly IDbContextFactory<AppDbContext> _contextFactory;

    public AuthService(IDbContextFactory<AppDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<User?> RegisterAsync(string username, string password)
    {
        Console.WriteLine($"AuthService.RegisterAsync called with username='{username}' passwordLength={password?.Length ?? 0}");
        using var context = await _contextFactory.CreateDbContextAsync();

        // Check if username is taken
        if (await context.Users.AnyAsync(u => u.Username == username))
        {
            return null;
        }

        var user = new User
        {
            Username = username,
            PasswordHash = HashPassword(password),
            Role = "User"
        };

        context.Users.Add(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> LoginAsync(string username, string password)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        var user = await context.Users
            .FirstOrDefaultAsync(u => u.Username == username);

        if (user == null || !VerifyPassword(password, user.PasswordHash))
        {
            return null;
        }

        return user;
    }

    public string HashPassword(string password)
    {
        // Generate a random salt
        byte[] salt = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        // Hash the password with PBKDF2
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

        // Combine salt and hash
        return $"{Convert.ToBase64String(salt)}.{hashed}";
    }

    public bool VerifyPassword(string password, string storedHash)
    {
        // Extract salt and hash
        var parts = storedHash.Split('.');
        if (parts.Length != 2)
            return false;

        var salt = Convert.FromBase64String(parts[0]);
        var hash = parts[1];

        // Hash the input password with the same salt
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

        return hash == hashed;
    }
}