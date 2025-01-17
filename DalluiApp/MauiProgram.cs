using Microsoft.Extensions.Logging;
using PanCardView;
using CommunityToolkit.Maui;
using DalluiApp.Helpers;

namespace DalluiApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseCardsView()
			.UseMauiCommunityToolkit()
            .RegisterPages(BootStrapper.GetPages())
			.RegisterViewModels(BootStrapper.GetViewModels())
			.ConfigureAllFonts(BootStrapper.GetAppSpecificFonts())
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		LocalizationHelper.InitTranslation("en");

        return builder.Build();
	}	
}

