using BlazingQuiz;
using BlazingQuiz.Web;
using BlazingQuiz.Web.Apis;
using BlazingQuiz.Web.Auth;
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
builder.Services.AddSingleton<AuthenticationStateProvider>(sp=>sp.GetRequiredService<QuizAuthStateProvider>());
ConfigureRefit(builder.Services);
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();

static void ConfigureRefit(IServiceCollection services)
{
    const string ApiBaseUrl = "https://localhost:7247";
    services.AddRefitClient<IAuthApi>().ConfigureHttpClient(httpClient=>httpClient.BaseAddress=new Uri(
         ApiBaseUrl));
}