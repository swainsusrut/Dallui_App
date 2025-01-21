using System;
using DalluiApp.Views;

namespace DalluiApp
{
    public static class BootStrapper
    {
        public static Dictionary<string, string> GetAppSpecificFonts()
        {
            return new Dictionary<string, string>()
            {
                 { "Nexa-ExtraLight.ttf", "NexaLight"},
                 { "Nexa-Heavy.ttf", "NexaHeavy"}
            };
        }

        public static Dictionary<Type, Type> GetHandlers()
        {
            return new Dictionary<Type, Type>()
            {
            };
        }

        public static Dictionary<Type, Type> GetServices()
        {
            return new Dictionary<Type, Type>()
            {
            };
        }

        public static List<Type> GetPages()
        {
            return new List<Type>()
            {
                typeof(DashboardView),
                typeof(GenerationOptionsView),
                typeof(ImageGeneratorView)
            };
        }

        public static List<Type> GetViewModels()
        {
            return new List<Type>()
            {
                typeof(DashboardViewModel),
                typeof(GenerationOptionsViewModel),
                typeof(ImageGeneratorViewModel)
            };
        }

        public static Dictionary<Type, Type> GetRoutes()
        {
            //If a page is not part of the Shell Hierarchy, you have to register the routes.
            return new Dictionary<Type, Type>()
            {
                { typeof(GenerationOptionsViewModel), typeof(GenerationOptionsView) }
            };
        }
    }
}

