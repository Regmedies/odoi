using System.Collections.Generic;

namespace SampleFunctionAppNew.Types
{
    public class MultiType
    {
        private readonly Dictionary<string, string> _dictionary;

        public MultiType(Dictionary<string, string> dictionary)
        {
            _dictionary = dictionary;
        }

        public static implicit operator Dictionary<string, string>(MultiType d) => d?._dictionary;

        public static explicit operator MultiType(Dictionary<string, string> dictionary) => new MultiType(dictionary);
    }
}
