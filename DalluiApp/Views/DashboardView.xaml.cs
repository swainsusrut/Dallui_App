namespace DalluiApp.Views;

public partial class DashboardView : ContentPage
{
	public DashboardView(DashboardViewModel dashboardViewModel)
	{
		InitializeComponent();
		BindingContext = dashboardViewModel;
	}
}
