using System;
using Newtonsoft.Json;

namespace DalluiApp.Models
{
    public class Language
    {
        [JsonProperty("LanguageId")]
        public int LanguageId { get; set; } = 0;

        [JsonProperty("Code")]
        public required string Code { get; set; }

        [JsonProperty("Name")]
        public required string Name { get; set; }

        [JsonProperty("Desc")]
        public required string Desc { get; set; }

        [JsonProperty("ServerLanguageCode")]
        public required string ServerLanguageCode { get; set; }

        [JsonProperty("LocaleIdentifier")]
        public required string LocaleIdentifier { get; set; }
    }
}

