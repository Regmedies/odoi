using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Concurrent;

namespace SampleFunctionAppNew.Models
{
    public class UpdateWebhookMessage
    {
        [JsonProperty("field_107")]
    public Dictionary<string,string> Join { get; set; }
    }
}
