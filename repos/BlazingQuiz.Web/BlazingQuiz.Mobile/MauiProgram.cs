using BlazingQuiz.Mobile.Services;
using BlazingQuiz.Shared;
using BlazingQuiz.Shared.Components.Auth;
using BlazingQuiz.Web.Apis;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using Refit;
using System.Net.Http;


#if ANDROID
using Xamarin.Android.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;


#elif IOS
using Security;

#endif

namespace BlazingQuiz.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddSingleton<QuizAuthStateProvider>();
            builder.Services.AddSingleton<AuthenticationStateProvider>(sp => sp.GetRequiredService<QuizAuthStateProvider>());
            builder.Services.AddAuthorizationCore();


            builder.Services.AddSingleton<IStorageService, StorageService>()
                .AddSingleton<IAppState, AppState>()
                .AddSingleton<QuizState>()
                .AddSingleton<IPlatform,MobilePlatform>();
                

            ConfigureRefit(builder.Services);
            return builder.Build();
        }


        //private static readonly string ApiBaseUrl= 
        //    DeviceInfo.DeviceType == DeviceType.Physical
        //    ? "https://hkfw297w-7247.use2.devtunnels.ms"
        //    :
        //    DeviceInfo.Platform == DevicePlatform.Android
        //          ? "https://10.0.2.2:7247"
        //          : "https://localhost:7247";
        static void ConfigureRefit(IServiceCollection services)
        {
            var apiUrlBase = "https://localhost:7247";
            if (DeviceInfo.DeviceType==DeviceType.Physical|| DeviceInfo.Platform==DevicePlatform.iOS)
            {
                apiUrlBase = "https://hkfw297w-7247.use2.devtunnels.ms";
            }
            else if (DeviceInfo.Platform==DevicePlatform.Android)
                {
                    apiUrlBase = "https://10.0.2.2:7247";
                }

              
            



            services.AddRefitClient<IAuthApi>(GetRefitSettings)
                .ConfigureHttpClient(SetHttpClient);
            
            services.AddRefitClient<ICategoryApi>(GetRefitSettings)
                .ConfigureHttpClient(SetHttpClient);
            
            services.AddRefitClient<IStudentQuizApi>(GetRefitSettings)
                .ConfigureHttpClient(SetHttpClient);

     

             void SetHttpClient(HttpClient httpClient)
                => httpClient.BaseAddress = new Uri(
                 apiUrlBase);

            static RefitSettings GetRefitSettings(IServiceProvider sp)
            {
                var authStateProvider = sp.GetRequiredService<QuizAuthStateProvider>();
                return new RefitSettings
                {
                    AuthorizationHeaderValueGetter =  (_, __) =>
                     Task.FromResult(authStateProvider.User?.Token ?? ""),
                    
                    HttpMessageHandlerFactory = () =>
                    {
                        // Android-specific message handler
#if ANDROID
            var androidMessageHandler = new AndroidMessageHandler
            {ServerCertificateCustomValidationCallback =
                (HttpRequestMessage requestMessage, X509Certificate2? certificate2, 
                X509Chain? chain, SslPolicyErrors sslPolicyErrors) 
                =>
               certificate2?.Issuer=="CN=localhost"|| sslPolicyErrors==SslPolicyErrors.None
           };
                return androidMessageHandler;
#elif IOS
                 var nsUrlSessionHandler = new NSUrlSessionHandler
                        { 
                       //we should not have this for production use
                          TrustOverrideForUrl =(
                              NSUrlSessionHandler sender, string url, SecTrust trust)
                           => url.StartsWith("https://localhost") //if we are running api on this local device (mac only)
                           || url.Contains("devtunnels.ms") // if we are using devtunnels

                         };
                     return nsUrlSessionHandler;
#endif
                        return null;
                    }
                };
            }
        }
        }



    }





