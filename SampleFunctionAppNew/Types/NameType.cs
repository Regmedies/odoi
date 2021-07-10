using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SampleFunctionAppNew.Types
{
    public class NameType
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }
    }
}
