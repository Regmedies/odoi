using Newtonsoft.Json;
using System.Collections.Generic;
using SampleFunctionAppNew.Converters;
using SampleFunctionAppNew.Types;

namespace SampleFunctionAppNew.Models
{
    public class CopyFromModel
    {
        public string Id { get; set; }

        [JsonProperty("field_76")]
        public string Text { get; set; }

        [JsonProperty("field_80")]
        public string LongText { get; set; }

        [JsonProperty("field_81")]
        public string RichText { get; set; }

        [JsonProperty("field_82")]
        public NameType Name { get; set; }

        [JsonProperty("field_83")]
        public string Email { get; set; }

        [JsonProperty("field_84")]
        public AddressType Address { get; set; }

        [JsonProperty("field_85")]
        public string Phone { get; set; }

        [JsonProperty("field_86")]
        public string Number { get; set; }

        [JsonProperty("field_87")]
        public string Currency { get; set; }

        [JsonProperty("field_88")]
        public string BasicFormula { get; set; }

        [JsonProperty("field_91")]
        public string ComplexFormula { get; set; }

        [JsonProperty("field_92")]
        public string Equation { get; set; }

        [JsonProperty("field_93")]
        public string Date { get; set; }

        [JsonProperty("field_94")]
        public TimeType Time { get; set; }

        [JsonProperty("field_95")]
        public CalendarType DateRange { get; set; }

        [JsonProperty("field_96")]
        public string DateFormula { get; set; }

        [JsonProperty("field_97")]
        [JsonConverter(typeof(MultiTypeConverter))]
        public MultiType Checkbox { get; set; }

        [JsonProperty("field_98")]
        public string Radio { get; set; }

        [JsonProperty("field_99")]
        public string Select { get; set; }

        [JsonProperty("field_100")]
        public string DecisionBox { get; set; }

        [JsonProperty("field_101")]
        public string SelectWithScore { get; set; }

        [JsonProperty("field_102")]
        public string Rating { get; set; }

        [JsonProperty("field_103")]
        public LinkType Link { get; set; }

        [JsonProperty("field_107")]
        public Dictionary<string, string> Join { get; set; }

        [JsonProperty("field_108")]
        public string TextFormula { get; set; }

        [JsonProperty("field_132")]
        public string Slider { get; set; }

        [JsonProperty("field_136")]
        public string DateTime { get; set; }

        [JsonProperty("field_138")]
        [JsonConverter(typeof(MultiTypeConverter))]
        public MultiType MultiSelect { get; set; }

    }
}
