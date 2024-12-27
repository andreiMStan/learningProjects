using System.Data;
using System.Security.Claims;
using System.Text.Json;
using BlazingQuiz.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace BlazingQuiz.Web.Auth
{
    public class QuizAuthStateProvider:AuthenticationStateProvider
    {
        private const string AuthType = "quiz-auth";
        private const string UserDataKey = "udata";

        private   Task<AuthenticationState>_authStateTask;
        private readonly IJSRuntime _jSRuntime;
        

        public QuizAuthStateProvider(IJSRuntime jSRuntime)
        {
           _jSRuntime = jSRuntime;
            SetAuthStateTask(); 
        }
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
            =>_authStateTask;

        public LoggedInUser User { get; private set; }
        public bool IsLoggedIn => User?.Id > 0;
        public async Task SetLoginAsync(LoggedInUser user)
        {
            User = user;
            SetAuthStateTask();
            NotifyAuthenticationStateChanged(_authStateTask);
            await _jSRuntime.InvokeVoidAsync("localStorage.setItem",UserDataKey, user.ToJson());
        }
        public async Task SetLogoutAsync()
        {
            User = null; 
            SetAuthStateTask();
            NotifyAuthenticationStateChanged(_authStateTask);
             await _jSRuntime.InvokeVoidAsync("localStorage.removeItem", UserDataKey);
        }

        public bool IsInitializing { get; set; } = true;
        public async Task InitializeAsync()
        {
            try
            {
                var udata = await _jSRuntime.InvokeAsync<string?>("localStorage.getItem", UserDataKey);
                if (string.IsNullOrWhiteSpace(udata))
                {
                    //User data /state is not there in the browser's storage
                    return;
                }

                var user = LoggedInUser.LoadFrom(udata);
                if (user == null || user.Id == 0)
                {
                    //user data state is not valid
                    return;
                }
                await SetLoginAsync(user);
            }
            catch(Exception ex)
            {
              //todo fix error 
              //SetLoginAsyinc from this initializeAsync method throws enumeration
             //collection vas modified- enumeration has change
             //on the notifyauthenticationstatechange in the setloginasync method
            }
            finally
            {
                IsInitializing = false; 
            }
        }
        private void SetAuthStateTask()
        {
            if (IsLoggedIn )
            {
                var identity = new ClaimsIdentity(User.ToClaims(),AuthType);
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
}
