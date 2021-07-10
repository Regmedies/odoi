using Newtonsoft.Json;

namespace SampleFunctionAppNew.Types
{
    public class LinkType
    {
        [JsonProperty("link")]
        public string Link { get; set; }
    }
}
