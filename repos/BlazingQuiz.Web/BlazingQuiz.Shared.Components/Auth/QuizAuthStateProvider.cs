using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using BlazingQuiz.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;

namespace BlazingQuiz.Shared.Components.Auth;
public class QuizAuthStateProvider : AuthenticationStateProvider
{
    private const string AuthType = "quiz-auth";
    private const string UserDataKey = "udata";

    private Task<AuthenticationState> _authStateTask;
    private readonly IStorageService _storageService;
    private readonly NavigationManager _navigationManager;

    public QuizAuthStateProvider(IStorageService storageService, NavigationManager navigationManager)
    {
        _storageService = storageService;
        _navigationManager = navigationManager;
        SetAuthStateTask();
    }
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
        => _authStateTask;

    public LoggedInUser User { get; private set; }
    public bool IsLoggedIn => User?.Id > 0;

    public async Task SetLoginAsync(LoggedInUser user)
    {
        User = user;
        SetAuthStateTask();
        NotifyAuthenticationStateChanged(_authStateTask);
        await _storageService.SetItem
        (UserDataKey, user.ToJson());

    }
    public async Task SetLogoutAsync()
    {
        User = null;
        SetAuthStateTask();
        NotifyAuthenticationStateChanged(_authStateTask);
        await _storageService.RemoveItem
        (UserDataKey);

    }
    public bool IsInitializing { get; private set; } = true;

    public async Task InitializeAsync()
    {
        await InitializeAsync(redirectToLogin: true);
    }



    public async Task<bool> InitializeAsync(bool redirectToLogin = true)
    {
        try
        {
            var udata = await _storageService
            .GetItem(UserDataKey);

            if (string.IsNullOrWhiteSpace(udata))
            {  //User data /state is not there in the browser's storage
                if (redirectToLogin)
                    RedirectToLogin();
                return false;

            }

            var user = LoggedInUser.LoadFrom(udata);

            if (user == null || user.Id == 0)
            {
                if (redirectToLogin)
                    RedirectToLogin();
                return false;

            }
            //check if JWT Token is still valid(Not Expired

            if (!IsTokenValid(user.Token))
            {
                if (redirectToLogin)
                    RedirectToLogin();
                return false;

            }



            await SetLoginAsync(user);
            return true;
        }

        catch (Exception ex)
        {
            Console.WriteLine($"Error during initializatio");
       

        }

        finally
        {
            IsInitializing = false;
        }
        return false;
    }

    private void RedirectToLogin()
    {
        _navigationManager.NavigateTo("auth/login");
    }
    private static bool IsTokenValid(string token)
    {

        if (string.IsNullOrWhiteSpace(token))
            return false;

        var jwtHandler = new JwtSecurityTokenHandler();
        if (!jwtHandler.CanReadToken(token)) //invalid format token
            return false;

        var jwt = jwtHandler.ReadJwtToken(token);
        var expClaim = jwt.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp);
        if (expClaim == null)
            return false;


        var expTime = long.Parse(expClaim.Value);

        var expDatetimeUtc = DateTimeOffset.FromUnixTimeSeconds(expTime).UtcDateTime;

        return expDatetimeUtc > DateTime.UtcNow;
    }
    private void SetAuthStateTask()
    {
        if (IsLoggedIn)
        {
            var identity = new ClaimsIdentity(User.ToClaims(), AuthType);
            var principal = new ClaimsPrincipal(identity);
            var authState = new AuthenticationState(principal);
            _authStateTask = Task.FromResult(authState);
        }
        else
        {
            var identity = new ClaimsIdentity();
            var principal = new ClaimsPrincipal(identity);
            var authState = new AuthenticationState(principal);
            _authStateTask = Task.FromResult(authState);
        }
    }
}


