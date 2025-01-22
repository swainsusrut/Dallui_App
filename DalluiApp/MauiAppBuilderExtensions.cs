using System;
using System.Collections.Generic;
using DalluiApp.Helpers;

namespace DalluiApp
{
    public static class MauiAppBuilderExtensions
    {
        public static MauiAppBuilder ConfigureAllFonts(this MauiAppBuilder mauiAppBuilder, Dictionary<string, string> appSpecificFonts)
        {
            if (appSpecificFonts != null && appSpecificFonts.Any())
            {
                mauiAppBuilder.ConfigureFonts(fonts =>
                {
                    foreach (var font in appSpecificFonts)
                        fonts.AddFont(font.Key, font.Value);
                });
            }

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterHandlers(this MauiAppBuilder mauiAppBuilder, Dictionary<Type, Type> customHandlers)
        {
            mauiAppBuilder.ConfigureMauiHandlers(handlers =>
            {
                foreach (var handler in customHandlers)
                    handlers.AddHandler(handler.Key, handler.Value);
            });

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder, Dictionary<Type, Type> services)
        {
            if (services != null && services.Any())
            {
                foreach (var service in services)
                    mauiAppBuilder.Services.AddSingleton(service.Key, service.Value);
            }

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterPages(this MauiAppBuilder mauiAppBuilder, List<Type> pages)
        {
            foreach (var page in pages)
                mauiAppBuilder.Services.AddTransient(page);

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder, List<Type> viewModels)
        {
            foreach (var viewModel in viewModels)
                mauiAppBuilder.Services.AddTransient(viewModel);

            return mauiAppBuilder;
        }

        public static void RegisterRoutes(this MauiAppBuilder mauiAppBuilder, Dictionary<Type, Type> routes)
        {
            // Route is ViewModel name and Type is typeof(Page)
            foreach (var route in routes)
            {
                Routing.RegisterRoute(route.Key.Name, route.Value);
                //AppRoute.Register(route.Key, route.Value); //Requires parameterless constructor
            }
        }
    }
}

