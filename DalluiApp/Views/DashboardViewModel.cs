using System;
using System.Collections.ObjectModel;
using DalluiApp.Helpers;
using DalluiApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace DalluiApp.Views
{
	public partial class DashboardViewModel : ObservableObject
	{
        [ObservableProperty]
        private LocalizedResources resources;

        public ObservableCollection<Profile>? Profiles { get; set; }
        public ObservableCollection<GeneratedImage>? GeneratedImages { get; set; }

        public DashboardViewModel()
		{
            Resources = new LocalizedResources(LocalizationHelper.Translations);
            loadInitialData();
		}

        private void loadInitialData()
        {
            Profiles = new ObservableCollection<Profile>
            {
               new Profile
               {
                    Name = "Hector",
                    ProfileImage = AppConstants.ImageSource.Profile1,
                    NoOfPhotos = 12
               },
               new Profile
               {
                    Name = "Maddy",
                    ProfileImage = AppConstants.ImageSource.Profile2,
                    NoOfPhotos = 5
               },
               new Profile
               {
                    Name = "Henry",
                    ProfileImage = AppConstants.ImageSource.Profile3,
                    NoOfPhotos = 25
               }
            };

            GeneratedImages = new ObservableCollection<GeneratedImage>
            {
               new GeneratedImage
               {
                    ImagePath = AppConstants.ImageSource.Dashboard1,
                    MainKeyword = Resources[LocalizedResourceKeys.Castle],
                    Keywords = new List<string> {
                        Resources[LocalizedResourceKeys.Epic],
                        Resources[LocalizedResourceKeys.Hill],
                        Resources[LocalizedResourceKeys.Mountain],
                        Resources[LocalizedResourceKeys.Trees],
                        Resources[LocalizedResourceKeys.BlueSky]
                    }
               },
               new GeneratedImage
               {
                    ImagePath = AppConstants.ImageSource.Dashboard2,
                    MainKeyword = Resources[LocalizedResourceKeys.Mountains],
                    Keywords = new List<string> {
                        Resources[LocalizedResourceKeys.Landscape],
                        Resources[LocalizedResourceKeys.Photorealistic],
                        Resources[LocalizedResourceKeys.Dawn],
                        Resources[LocalizedResourceKeys.Mountains],
                        Resources[LocalizedResourceKeys.Moon]
                    }
               },
               new GeneratedImage
               {
                    ImagePath = AppConstants.ImageSource.Dashboard3,
                    MainKeyword = Resources[LocalizedResourceKeys.Robot],
                    Keywords = new List<string> {
                        Resources[LocalizedResourceKeys.AI],
                        Resources[LocalizedResourceKeys.Robotic],
                        Resources[LocalizedResourceKeys.Human],
                        Resources[LocalizedResourceKeys.Light],
                        Resources[LocalizedResourceKeys.Metal]
                    }
               },
            }; 
        }

        [RelayCommand]
        private async Task CreateImageTapped(Button button)
        {
            Debug.WriteLine(nameof(CreateImageTapped));
            if (button != null)
            {
                await button.FadeTo(0, 100);
                await button.FadeTo(1, 100);
            }

            //Fix Navigation issue
            //await Shell.Current.GoToAsync(nameof(GenerationOptionsViewModel));
        }
    }
}

