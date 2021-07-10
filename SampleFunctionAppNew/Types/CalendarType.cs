using System;
using Newtonsoft.Json;

namespace SampleFunctionAppNew.Types
{
    public class CalendarType
    {
        [JsonProperty("start")]
        public DateTime Start { get; set; }

        [JsonProperty("end")]
        public DateTime End { get; set; }
    }
}
