using System.Diagnostics;

namespace DalluiApp.Views;

public partial class ImageGeneratorView : ContentPage
{
    Stopwatch watch = new Stopwatch();

    public ImageGeneratorView(ImageGeneratorViewModel imageGeneratorViewModel)
	{
		InitializeComponent();
        BindingContext = imageGeneratorViewModel;
    }

    protected override async void OnAppearing()
    {
        await Task.Delay(TimeSpan.FromSeconds(2));
        watch.Start();

        var cancellationToken = new CancellationTokenSource();

        using (var timer = new PeriodicTimer(TimeSpan.FromSeconds(1)))
        {
            try
            {
                var counter = 0;
                while (await timer.WaitForNextTickAsync(cancellationToken.Token))
                {
                    if (counter == 3)
                    {
                        cancellationToken.Cancel();
                    }

                    var seconds = watch.Elapsed.Seconds;
                    lblTimer.Text = seconds.ToString();
                    counter++;
                }

            }
            catch (TaskCanceledException)
            {
                await StopGeneration();
            }
        }
    }

    private async Task StopGeneration()
    {
        watch.Stop();

        //Stop and hide Lottie animation
        lottie.IsAnimationEnabled = false;
        lottie.IsVisible = false;

        await Task.Delay(30);

        //Display the Image
        imageBorder.IsVisible = true;
        imageAnimation.IsVisible = true;
        await imageBorder.FadeTo(1, 100);

        await Task.WhenAny(
             //Scale to larger size and finally fade to zero
             imageAnimation.ScaleTo(1.1, 2000),
             imageAnimation.FadeTo(0, 2000),

             //Scale highlight to original size from larger size and finally fade to full opacity
             borderTime.ScaleTo(1, 2000),
             borderTime.FadeTo(1, 2000)
             );

        //Fade highlight to opacity zero
        await borderTime.FadeTo(0, 500);

        //Fade to display the button
        await btnFinish.ScaleTo(1, 400);
    }
}
