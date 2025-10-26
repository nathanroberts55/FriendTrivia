using Microsoft.AspNetCore.Components.Authorization;
using FriendTrivia.Services;
using FriendTrivia.Models;
using System.Security.Claims;

public class FriendTriviaAuthStateProvider : AuthenticationStateProvider, IDisposable
{
    private readonly AuthService _authService;
    public User CurrentUser { get; private set; } = new();

    public FriendTriviaAuthStateProvider(AuthService authService)
    {
        _authService = authService;
        AuthenticationStateChanged += OnAuthenticationStateChangedAsync;
    }

    public async Task<bool> LoginAsync(string username, string password)
    {
        var principal = new ClaimsPrincipal();
        var user = await _authService.LoginAsync(username, password);

        if (user is not null)
        {
            await _authService.PersistUserToBrowserAsync(user);
            principal = user.ToClaimsPrincipal();
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
            return true;
        }
        return false;

    }

    public async Task LogoutAsync()
    {
        await _authService.ClearBrowserUserDataAsync();
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new())));
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var principal = new ClaimsPrincipal();
        var user = await _authService.FetchUserFromBrowserAsync();

        if (user is not null)
        {
            var userInDatabase = await _authService.LoginAsync(user.Username, user.PasswordHash);

            if (userInDatabase is not null)
            {
                principal = userInDatabase.ToClaimsPrincipal();
                CurrentUser = userInDatabase;
            }
        }
        return new(principal);
    }

    private async void OnAuthenticationStateChangedAsync(Task<AuthenticationState> task)
    {
        var authenticationState = await task;

        if (authenticationState is not null)
        {
            CurrentUser = User.FromClaimsPrincipal(authenticationState.User);
        }
    }

    public void Dispose() => AuthenticationStateChanged -= OnAuthenticationStateChangedAsync;
}