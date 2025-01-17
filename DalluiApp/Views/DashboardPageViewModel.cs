using System;
using System.Collections.ObjectModel;
using DalluiApp.Helpers;
using DalluiApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DalluiApp.Views
{
	public partial class DashboardPageViewModel : ObservableObject
	{
        [ObservableProperty]
        private LocalizedResources resources;

        public ObservableCollection<Profile>? Profiles { get; set; }
        public ObservableCollection<GeneratedImage>? GeneratedImages { get; set; }

        public DashboardPageViewModel()
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
                    ProfileImage = "ic_profile1.jpg",
                    NoOfPhotos = 12
               },
               new Profile
               {
                    Name = "Maddy",
                    ProfileImage = "ic_profile2.jpg",
                    NoOfPhotos = 5
               },
               new Profile
               {
                    Name = "Henry",
                    ProfileImage = "ic_profile3.jpg",
                    NoOfPhotos = 25
               }
            };

            GeneratedImages = new ObservableCollection<GeneratedImage>
            {
               new GeneratedImage
               {
                    ImagePath = "ic_dashboard1.jpg",
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
                    ImagePath = "ic_dashboard2.jpg",
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
                    ImagePath = "ic_dashboard3.jpg",
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
    }
}

