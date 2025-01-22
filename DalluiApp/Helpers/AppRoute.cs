using System;
using System.Collections.Generic;

namespace DalluiApp.Helpers
{
    public class AppRoute : RouteFactory
    {
        private static readonly Dictionary<Type, Type> _mappings = new Dictionary<Type, Type>();
        private readonly Type _pageType;

        public AppRoute(Type viewModelType, Type pageType)
        {
            _pageType = pageType;
            _mappings.Add(viewModelType, pageType);
        }

        public static Type GetPageByViewModel(Type viewModel)
        {
            if (!_mappings.ContainsKey(viewModel))
            {
                throw new KeyNotFoundException($"No map for ${viewModel} was found on navigation mappings");
            }

            return _mappings[viewModel];
        }

        public static Type GetViewModelByPage(Type page)
        {
            if (!_mappings.ContainsValue(page))
            {
                throw new KeyNotFoundException($"No map for ${page} was found on navigation mappings");
            }

            return _mappings.FirstOrDefault(x => x.Value == page).Key;
        }

        public static void Register(Type viewModel, Type page)
        {
            Routing.RegisterRoute(viewModel.Name,
                new AppRoute(viewModel, page));
        }

        public override Element? GetOrCreate()
        {
            return (Element?)Activator.CreateInstance(_pageType);
        }

        public override Element? GetOrCreate(IServiceProvider services)
        {
            return (Element?)Activator.CreateInstance(_pageType);
        }
    }
}

