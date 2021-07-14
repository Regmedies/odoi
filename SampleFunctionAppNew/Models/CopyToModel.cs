using Newtonsoft.Json;
using System.Collections.Generic;
using SampleFunctionAppNew.Types;

namespace SampleFunctionAppNew.Models
{
    public class CopyToModel
    {
        [JsonProperty("field_77")]
        public string Text { get; set; }

        [JsonProperty("field_89")]
        public string Connection { get; set; }

        [JsonProperty("field_90")]
        public string Avarage { get; set; }

        [JsonProperty("field_109")]
        public string LongText { get; set; }

        [JsonProperty("field_110")]
        public string RichText { get; set; }

        [JsonProperty("field_111")]
        public NameType Name { get; set; }

        [JsonProperty("field_112")]
        public string Email { get; set; }

        [JsonProperty("field_113")]
        public AddressType Address { get; set; }

        [JsonProperty("field_114")]
        public string Phone { get; set; }

        [JsonProperty("field_115")]
        public string Number { get; set; }

        [JsonProperty("field_116")]
        public string Currency { get; set; }

        [JsonProperty("field_117")]
        public string BasicFormula { get; set; }

        [JsonProperty("field_118")]
        public string ComplexFormula { get; set; }

        [JsonProperty("field_119")]
        public string Equation { get; set; }

        [JsonProperty("field_120")]
        public string Date { get; set; }

        [JsonProperty("field_121")]
        public TimeType Time { get; set; }

        [JsonProperty("field_137")]
        public CalendarType DateRange { get; set; }

        [JsonProperty("field_123")]
        public string DateFormula { get; set; }

        [JsonProperty("field_124")]
        public MultiType Checkbox { get; set; }

        [JsonProperty("field_125")]
        public string Radio { get; set; }

        [JsonProperty("field_126")]
        public string Select { get; set; }

        [JsonProperty("field_128")]
        public string DecisionBox { get; set; }

        [JsonProperty("field_129")]
        public string SelectWithScore { get; set; }

        [JsonProperty("field_130")]
        public string Rating { get; set; }

        [JsonProperty("field_131")]
        public LinkType Link { get; set; }

        [JsonProperty("field_134")]
        public Dictionary<string, string> Join { get; set; }

        [JsonProperty("field_135")]
        public string TextFormula { get; set; }

        [JsonProperty("field_133")]
        public string Slider { get; set; }

        [JsonProperty("field_122")]
        public string DateTime { get; set; }

        [JsonProperty("field_127")]
        public MultiType MultiSelect { get; set; }

    }
}
