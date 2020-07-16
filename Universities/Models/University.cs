using Newtonsoft.Json;
using System.Collections.Generic;

namespace Universities.Models
{
    public class University
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("web_pages")]
        public List<string> Web { get; set; }
    }
}
