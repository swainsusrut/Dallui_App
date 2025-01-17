using System;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DalluiApp.Helpers
{
	public class LocalizedResources
	{
        private Dictionary<string, string>? _translations;

        public LocalizedResources(Dictionary<string, string>? translations)
        {
            _translations = translations;
        }

        public string this[string key]
        {
            get
            {
                try
                {
                    if (_translations != null && !string.IsNullOrEmpty(key) && _translations.ContainsKey(key))
                        return _translations[key];
                    else
                        return string.Empty;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return string.Empty;
                }
            }
        }
    }
}

