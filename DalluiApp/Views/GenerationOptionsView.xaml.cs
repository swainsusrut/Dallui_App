namespace DalluiApp.Views;

public partial class GenerationOptionsView : ContentPage
{
	public GenerationOptionsView(GenerationOptionsViewModel generationOptionsViewModel)
	{
		InitializeComponent();
		BindingContext = generationOptionsViewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _startAnimation();
    }

    private async void _startAnimation()
    {
        await _setInitialPositionAsync();

        _animateCloseButtonAsync();
        _animateHeadersAsync();
        _animateOptionsCollectionAsync();
        _animateInstructionLabelAsync();
        _animateStyleCollectionAsync();
        _animateEditorAsync();
        _animateButtonAsync();
    }

    private async Task _setInitialPositionAsync()
    {
        //Headlines
        lblHeadline.Opacity = 0;
        lblSubHeadline.Opacity = 0;
        lblHeadline.TranslationX = 400;
        lblSubHeadline.TranslationX = -400;

        //Options Collection
        optionsCollection.Opacity = 0;
        optionsCollection.Scale = 0;

        //Instruction Label
        lblInstruction.Opacity = 0;
        lblInstruction.TranslationX = 400;

        //Style Collection
        styleCollection.Opacity = 0;
        styleCollection.Scale = 0;

        //Editor
        editor.Opacity = 0;
        editor.Scale = 0;

        //Button
        generateButton.Opacity = 0;
        generateButton.Scale = 0;

        //Close Button
        closeButton.Scale = 0;

        await Task.Delay(100);
    }

    private async void _animateCloseButtonAsync()
    {
        await Task.WhenAny(
            closeButton.ScaleTo(1, 1500, Easing.CubicOut),
            closeButton.RotateTo(closeButton.Rotation + 360, 1500, Easing.CubicOut)
        );
    }

    private async void _animateHeadersAsync()
    {
        await Task.WhenAny(
            lblHeadline.TranslateTo(0, lblHeadline.Y, 1500),
            lblHeadline.FadeTo(1, 1500),
            lblSubHeadline.TranslateTo(0, lblHeadline.Y, 1500),
            lblSubHeadline.FadeTo(1, 1500)
        );
    }

    private async void _animateOptionsCollectionAsync()
    {
        await Task.WhenAny(
            optionsCollection.ScaleTo(1, 1500),
            optionsCollection.FadeTo(1, 1500)
        );
    }

    private async void _animateInstructionLabelAsync()
    {
        await Task.WhenAny(
            lblInstruction.FadeTo(1, 1500),
            lblInstruction.TranslateTo(0, 0, 1500)
        );
    }

    private async void _animateStyleCollectionAsync()
    {
        await Task.WhenAny(
            styleCollection.ScaleTo(1, 1500),
            styleCollection.FadeTo(1, 1500)
        );
    }

    private async void _animateEditorAsync()
    {
        await Task.WhenAny(
            editor.ScaleTo(1, 1500),
            editor.FadeTo(1, 1500)
        );
    }

    private async void _animateButtonAsync()
    {
        await Task.WhenAny(
            generateButton.ScaleTo(1, 1500),
            generateButton.FadeTo(1, 1500)
        );
    }
}
