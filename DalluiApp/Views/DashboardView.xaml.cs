namespace DalluiApp.Views;

public partial class DashboardView : ContentPage
{
	public DashboardView(DashboardViewModel dashboardViewModel)
	{
		InitializeComponent();
		BindingContext = dashboardViewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _startAnimation();
    }

    private async void _startAnimation()
	{
        await _setInitialPositionAsync();

        await _animateMenuItemsAsync();
        await _animateHeadersAsync();
        await _animateFriendsCollectionAsync();
        await _animateImageCollectionAsync();
        await _animateButtonAsync();
    }

    private async Task _setInitialPositionAsync()
    {
        //Profile Icon
        profileIcon.RotationY = -180;
        profileIcon.Opacity = 0.1;
        profileIcon.Scale = 0.1;

        //Menu Icon
        menuIcon.Scale = 0;
        menuIcon.Opacity = 0.1;

        //Headlines
        lblHeadline.Opacity = 0;
        lblSubHeadline.Opacity = 0;
        lblHeadline.TranslationX = 400;
        lblSubHeadline.TranslationX = -400;

        //Friends Collection
        friendsCollection.Opacity = 0;
        friendsCollection.TranslationX = 400;

        //Image Collection
        imageCollection.Opacity = 0;
        imageCollection.Scale = 0;

        //Button
        btnBorder.Opacity = 0;
        btnBorder.TranslationY = 100;

        await Task.Delay(100);
    }

    private async Task _animateMenuItemsAsync()
    {
        await Task.WhenAny(
            profileIcon.FadeTo(1, 1500, Easing.BounceIn),
            profileIcon.ScaleTo(1, 1500, Easing.BounceIn),
            profileIcon.RotateYTo(0, 1500, Easing.BounceIn),
            menuIcon.FadeTo(1, 1500),
            menuIcon.ScaleTo(1, 1500)
        );
        await Task.Delay(20);
    }

    private async Task _animateHeadersAsync()
    {
        await Task.WhenAny(
            lblHeadline.TranslateTo(0, lblHeadline.Y, 800),
            lblHeadline.FadeTo(1, 800),
            lblSubHeadline.TranslateTo(0, lblHeadline.Y, 800),
            lblSubHeadline.FadeTo(1, 800)
        );
        await Task.Delay(20);
    }

    private async Task _animateFriendsCollectionAsync()
    {
        await Task.WhenAny(
            friendsCollection.TranslateTo(0, lblHeadline.Y, 700, Easing.CubicInOut),
            friendsCollection.FadeTo(1, 700)
        );

        //Animation for children is not working. To check this, change the initial scale of these elements in xaml file to 0
        //Iterate through each item of collection view
        for (int index = 0; index < friendsCollection.ItemsSource.Cast<object>().Count(); index++)
        {
            //Access the item by its index
            var item = friendsCollection.ItemsSource.Cast<object>().ElementAt(index);

            //Create a new instance of the DataTemplate to access elements
            var grid = (Grid)friendsCollection.ItemTemplate.CreateContent();
            var profileBorder = (Border?)grid.Children.FirstOrDefault(child => child is Border && ((Border)child).FindByName("profileBorder") != null);
            var friendsStack = (VerticalStackLayout?)grid.Children.FirstOrDefault(child => child is VerticalStackLayout && ((VerticalStackLayout)child).FindByName("friendsStack") != null);
            //var lblName = (Label?)friendsStack?.Children.FirstOrDefault(child => child is Label && ((Label)child).FindByName("lblName") != null);
            //var lblInfo = (Label?)friendsStack?.Children.FirstOrDefault(child => child is Label && ((Label)child).FindByName("lblInfo") != null);

            // If the elements are found, animate them
            if (profileBorder != null && friendsStack != null)
            {
                /*
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await Task.WhenAny(
                        profileBorder.ScaleTo(1, 500),
                        friendsStack.ScaleTo(1, 500)
                    );
                });
                */
            }
        }

        await Task.Delay(20);
    }

    private async Task _animateImageCollectionAsync()
    {
        await Task.WhenAny(
            imageCollection.FadeTo(1, 800),
            imageCollection.ScaleTo(1, 800, Easing.SpringOut)
        );
    }

    private async Task _animateButtonAsync()
    {
        await Task.WhenAny(
            btnBorder.FadeTo(1, 300),
            btnBorder.TranslateTo(createButton.X, 0, 300)
        );
    }
}
