using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using DalluiApp.Models;
using Newtonsoft.Json;

namespace DalluiApp.Helpers
{
	public static class LocalizationHelper
	{
        private static string LanguageFolder => Path.Combine(FileSystem.AppDataDirectory, "language");
        private static Assembly _assembly = Assembly.GetExecutingAssembly();

        public static Dictionary<string, string>? Translations;

        public static void InitTranslation(string currentSelectedLanguage)
        {
            //Gets the list of all the embedded resources in this assembly
            var embeddedResourceNames = _assembly.GetManifestResourceNames().ToList();
            if (!Directory.Exists(LanguageFolder))
            {
                Directory.CreateDirectory(LanguageFolder);
            }

            //Reads the list of supported Languages for this app
            var languageCodesJson = LoadEmbeddedResource(_assembly, AppConstants.ResourceLanguageId);
            var AllLanguagesData = JsonConvert.DeserializeObject<AllLanguages>(languageCodesJson, new JsonSerializerSettings {
                                                                                NullValueHandling = NullValueHandling.Ignore,
                                                                                MissingMemberHandling = MissingMemberHandling.Ignore
                                                                            });
            var _languageCodes = AllLanguagesData?.Languages;

            if (_languageCodes != null && _languageCodes.Any())
            {
                foreach (var language in _languageCodes)
                {
                    //Checks if this particular langauge file is available in the list of resources
                    var embeddedLanguageFileName = embeddedResourceNames.FirstOrDefault(emd => emd.Contains($".{language.Code}."));

                    if (!string.IsNullOrWhiteSpace(embeddedLanguageFileName))
                    {
                        //Loads the embedded resource from the sourceFilePath and Writes it to a directory
                        WriteLanguageFile(language.Code, embeddedLanguageFileName);
                    }
                    else
                    {
                        Debug.WriteLine("Error: Stream is null.");
                    }
                }
            }

            LoadSelectedLanguage(currentSelectedLanguage);
        }

        public static void LoadSelectedLanguage(string selectedLanguageCode)
        {
            if (string.IsNullOrWhiteSpace(selectedLanguageCode))
                return;

            Debug.WriteLine($"LoadSelectedLanguage called for: {selectedLanguageCode}");
            Translations = GetTranslation(selectedLanguageCode);
        }

        private static Dictionary<string, string>? GetTranslation(string languageCode)
        {
            try
            {
                //If embedded resource is already written to a directory, it will open, read all text in that file and will close it
                return JsonConvert.DeserializeObject<Dictionary<string, string>>
                        (File.ReadAllText(Path.Combine(LanguageFolder, $"{languageCode}.json")));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: getting translation - " + ex.StackTrace + " - " + ex.Message);

                //Else loads the embedded resource then writes it to a directory and finally reads it
                var embeddedResourceNames = _assembly.GetManifestResourceNames().ToList();
                var embeddedLanguageFileName = embeddedResourceNames.FirstOrDefault(emd => emd.Contains($".{languageCode}."));

                if (!string.IsNullOrWhiteSpace(embeddedLanguageFileName))
                {
                    WriteLanguageFile(languageCode, embeddedLanguageFileName);
                }
                else
                {
                    Debug.WriteLine("Error: Stream is null.");
                }

                return JsonConvert.DeserializeObject<Dictionary<string, string>>
                        (File.ReadAllText(Path.Combine(LanguageFolder, $"{languageCode}.json")));
            }
        }

        private static void WriteLanguageFile(string languageCode, string sourceFilePath)
        {
            var languageFilePath = Path.Combine(LanguageFolder, $"{languageCode}.json");

            var languagesJson = LoadEmbeddedResource(_assembly, sourceFilePath);
            File.WriteAllText(languageFilePath, languagesJson);
        }

        private static string LoadEmbeddedResource(Assembly assembly, string resourceName)
        {
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null) return string.Empty;
                using (var reader = new StreamReader(stream))
                    return reader.ReadToEnd();
            }
        }
    }
}

