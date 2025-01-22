using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DalluiApp.Helpers;
using DalluiApp.Models;

namespace DalluiApp.Views
{
	public partial class GenerationOptionsViewModel: ObservableObject
    {
        [ObservableProperty]
        private LocalizedResources resources;

        public ObservableCollection<string>? Options { get; set; }
        public ObservableCollection<ArtStyle>? Styles { get; set; }

        public GenerationOptionsViewModel()
		{
            Resources = new LocalizedResources(LocalizationHelper.Translations);
            FillOptions();
        }

        private void FillOptions()
        {
            Options = new ObservableCollection<string>
            {
                Resources[LocalizedResourceKeys.World],
                Resources[LocalizedResourceKeys.Winter],
                Resources[LocalizedResourceKeys.Trees],
                Resources[LocalizedResourceKeys.Separation],
                Resources[LocalizedResourceKeys.Solitude]
            };

            Styles = new ObservableCollection<ArtStyle>()
            {
                new ArtStyle() { Name = Resources[LocalizedResourceKeys.Cartoon], ImageUrl = AppConstants.ImageSource.Cartoon },
                new ArtStyle() { Name = Resources[LocalizedResourceKeys.Realistic], ImageUrl = AppConstants.ImageSource.Realistic },
                new ArtStyle() { Name = Resources[LocalizedResourceKeys.WatercolorArt], ImageUrl = AppConstants.ImageSource.Watercolor },
                new ArtStyle() { Name = Resources[LocalizedResourceKeys.Isometric], ImageUrl = AppConstants.ImageSource.Isometric },
                new ArtStyle() { Name = Resources[LocalizedResourceKeys.PopArt], ImageUrl = AppConstants.ImageSource.Popart },
                new ArtStyle() { Name = Resources[LocalizedResourceKeys.Surrealism], ImageUrl = AppConstants.ImageSource.Surrealism },
                new ArtStyle() { Name = Resources[LocalizedResourceKeys.Minimalism], ImageUrl = AppConstants.ImageSource.Minimalism },
                new ArtStyle() { Name = Resources[LocalizedResourceKeys.Funko], ImageUrl = AppConstants.ImageSource.Funko },
                new ArtStyle() { Name = Resources[LocalizedResourceKeys.Anime], ImageUrl = AppConstants.ImageSource.Anime },
                new ArtStyle() { Name = Resources[LocalizedResourceKeys.Storybook], ImageUrl = AppConstants.ImageSource.Storybook },
            };
        }

        [RelayCommand]
        private async Task CloseButtonTapped(ImageButton imageButton)
        {
            Debug.WriteLine(nameof(CloseButtonTapped));
            if (imageButton != null)
            {
                await imageButton.ScaleTo(0.8, 100);
                await imageButton.ScaleTo(1, 100);
            }

            await Shell.Current.Navigation.PopAsync(true);
        }

        [RelayCommand]
        private async Task GenerateButtonTapped(Button button)
        {
            Debug.WriteLine(nameof(GenerateButtonTapped));
            if (button != null)
            {
                await button.ScaleTo(0.8, 200);
                await button.ScaleTo(1, 200);
            }

            await Shell.Current.GoToAsync(nameof(ImageGeneratorViewModel));
        }
    }
}

