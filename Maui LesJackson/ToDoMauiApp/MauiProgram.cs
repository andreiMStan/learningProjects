using ToDoMauiApp.DataServices;
using ToDoMauiApp.Pages;

namespace ToDoMauiApp
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
																	fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
													});

										//		builder.Services.AddHttpClient<IRestDataService, RestDataService>();
											builder.Services.AddSingleton<IRestDataService, RestDataService>();

												builder.Services.AddSingleton<MainPage>();
												builder.Services.AddTransient<ManageToDoPage>();

												return builder.Build();
								}
				}
}
