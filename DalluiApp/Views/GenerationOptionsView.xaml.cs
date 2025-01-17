namespace DalluiApp.Views;

public partial class GenerationOptionsView : ContentPage
{
	public GenerationOptionsView(GenerationOptionsViewModel generationOptionsViewModel)
	{
		InitializeComponent();
		BindingContext = generationOptionsViewModel;
	}
}
