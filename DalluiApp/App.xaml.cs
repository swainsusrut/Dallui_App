using DalluiApp.Views;

namespace DalluiApp;

public partial class App : Application
{
	public App(IServiceProvider serviceProvider)
	{
		InitializeComponent();

		//App Shell is not used
		//MainPage = new AppShell();

		MainPage = serviceProvider.GetRequiredService<GenerationOptionsView>();
	}
}

