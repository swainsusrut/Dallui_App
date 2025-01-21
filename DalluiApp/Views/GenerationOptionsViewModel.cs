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
        private void CloseButtonTapped()
        {
            Debug.WriteLine(nameof(CloseButtonTapped));
        }
    }
}

