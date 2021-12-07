using Newtonsoft.Json;
using System;

namespace Panosen.Serialization.ElasticSearch
{
    public class Range
    {
        [JsonProperty("name")]
        public string Name { get; set;}

        [JsonProperty("gt")]
        public long? GreaterThan { get; set;}

        [JsonProperty("gte")]
        public long? GreateEqualThan { get; set;}

        [JsonProperty("lt")]
        public long? LessThan { get; set;}

        [JsonProperty("lte")]
        public long? LessEqualThan { get; set;}

        [JsonProperty("from")]
        public long? From { get; set;}

        [JsonProperty("to")]
        public long? To { get; set;}

        [JsonProperty("boost")]
        public int? Boost { get; set;}

        [JsonProperty("include_lower")]
        public bool? IncludeLower { get; set;}

        [JsonProperty("include_upper")]
        public bool? IncludeUpper { get; set;}

    }
}
