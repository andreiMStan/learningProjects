using ToDoMauiApp.Pages;

namespace ToDoMauiApp
{
				public partial class AppShell : Shell
				{
								public AppShell()
								{
												InitializeComponent();
												Routing.RegisterRoute(nameof(ManageToDoPage), typeof(ManageToDoPage));
								}
				}
}