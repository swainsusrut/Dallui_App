using DalluiApp.Views;

namespace DalluiApp;

public partial class App : Application
{
	public App(IServiceProvider serviceProvider)
	{
		InitializeComponent();

		MainPage = new AppShell();

		//MainPage = new NavigationPage(serviceProvider.GetRequiredService<DashboardView>());
	}
}

