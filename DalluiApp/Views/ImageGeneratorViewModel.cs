using System;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DalluiApp.Helpers;

namespace DalluiApp.Views
{
	public partial class ImageGeneratorViewModel: ObservableObject
    {
        [ObservableProperty]
        private LocalizedResources resources;

        public ImageGeneratorViewModel()
		{
            Resources = new LocalizedResources(LocalizationHelper.Translations);
        }

        [RelayCommand]
		private void FinishTapped()
		{
            Debug.WriteLine(nameof(FinishTapped));
        }
    }
}

