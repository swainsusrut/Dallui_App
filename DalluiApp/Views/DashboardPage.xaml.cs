namespace DalluiApp.Views;

public partial class DashboardPage : ContentPage
{
	public DashboardPage(DashboardPageViewModel dashboardPageViewModel)
	{
		InitializeComponent();
		BindingContext = dashboardPageViewModel;
	}
}
