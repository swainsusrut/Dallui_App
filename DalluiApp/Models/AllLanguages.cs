using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DalluiApp.Models
{
    public class AllLanguages
    {
        [JsonProperty("Version")]
        public int Version { get; set; }

        [JsonProperty("Languages")]
        public required List<Language> Languages { get; set; }
    }
}

