using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using SampleFunctionAppNew.Types;

namespace SampleFunctionAppNew.Converters
{
    /// <summary>
    /// This converter support for the Checkbox and MultiSelect type.
    /// Tadabase sometimes send string sometimes dictionary.
    /// </summary>
    public class MultiTypeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.String)
            {
                return new MultiType(new Dictionary<string, string>()
                {
                    { "0", token.Value<string>() }
                });
            }
            else if (token.Type == JTokenType.Object)
            {
                return new MultiType(token.ToObject<Dictionary<string, string>>());
            }
            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(MultiType));
        }
    }
}
