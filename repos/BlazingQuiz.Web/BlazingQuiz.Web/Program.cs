using BlazingQuiz;
using BlazingQuiz.Shared;
using BlazingQuiz.Shared.Components.Auth;
using BlazingQuiz.Shared.Components.Components;
using BlazingQuiz.Web;
using BlazingQuiz.Web.Apis;
using BlazingQuiz.Web.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<QuizAuthStateProvider>();
builder.Services.AddSingleton<AuthenticationStateProvider>(sp => sp.GetRequiredService<QuizAuthStateProvider>());
builder.Services.AddAuthorizationCore();

builder.Services.AddSingleton<IAppState,AppState>()
    .AddSingleton<QuizState>()
    .AddSingleton<IStorageService,StorageService>()
    .AddSingleton<IPlatform,WebPlatform>()
    ;

ConfigureRefit(builder.Services);

await builder.Build().RunAsync();

static void ConfigureRefit(IServiceCollection services)
{
    const string ApiBaseUrl = "https://localhost:7247";

    services.AddRefitClient<IAuthApi>()
        .ConfigureHttpClient(SetHttpClient);

    services.AddRefitClient<ICategoryApi>(GetRefitSetting)
        .ConfigureHttpClient(SetHttpClient);

    services.AddRefitClient<IQuizApi>(GetRefitSetting)
        .ConfigureHttpClient(SetHttpClient);
    
    services.AddRefitClient<IAdminApi>(GetRefitSetting)
        .ConfigureHttpClient(SetHttpClient);  

    services.AddRefitClient<IStudentQuizApi>(GetRefitSetting)
        .ConfigureHttpClient(SetHttpClient);

    static void SetHttpClient(HttpClient httpClient)
        =>httpClient.BaseAddress = new Uri(
         ApiBaseUrl);

    static RefitSettings GetRefitSetting(IServiceProvider sp)
    {
        var authStateProvider = sp.GetRequiredService<QuizAuthStateProvider>();
        return new RefitSettings
        {
            AuthorizationHeaderValueGetter = (_, __) => Task.FromResult
            (authStateProvider.User?.Token
            ?? "")
        };
    }
}