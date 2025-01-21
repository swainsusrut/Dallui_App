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
		private async Task FinishTapped(Button button)
		{
            Debug.WriteLine(nameof(FinishTapped));
            if (button != null)
            {
                await button.FadeTo(0, 100);
                await button.FadeTo(1, 100);
            }
        }
    }
}

