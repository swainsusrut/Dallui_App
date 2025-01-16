using System;
using System.Collections.ObjectModel;
using DalluiApp.Models;

namespace DalluiApp.Views
{
	public class DashboardPageViewModel
	{
		public ObservableCollection<Profile>? Profiles { get; set; }
        public ObservableCollection<GeneratedImage>? GeneratedImages { get; set; }

        public DashboardPageViewModel()
		{
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
                    MainKeyword = "Castle",
                    Keywords = new List<string> {
                         "Epic, Hill, Mountain, Trees, Blue sky"
                    }
               },
               new GeneratedImage
               {
                    ImagePath = "ic_dashboard2.jpg",
                    MainKeyword = "Mountains",
                    Keywords = new List<string> {
                         "Landscape, Photorealistic, Dawn, Mountains, Moon"
                    }
               },
               new GeneratedImage
               {
                    ImagePath = "ic_dashboard3.jpg",
                    MainKeyword = "Robot",
                    Keywords = new List<string> {
                         "AI, Robotic, Human, Light, Metal"
                    }
               },
            }; 
        }
    }
}

