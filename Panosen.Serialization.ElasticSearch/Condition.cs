using Newtonsoft.Json;
using System;

namespace Panosen.Serialization.ElasticSearch
{
    public class Condition
    {
        [JsonProperty("constant_score")]
        public ConstantScore ConstantScore { get; set;}

        [JsonProperty("bool")]
        public BoolQuery BoolQuery { get; set;}

        [JsonProperty("terms")]
        public Terms Terms { get; set;}

        [JsonProperty("term")]
        public Term Term { get; set;}

        [JsonProperty("ids")]
        public Ids Ids { get; set;}

        [JsonProperty("match")]
        public Match Match { get; set;}

        [JsonProperty("multi_match")]
        public MultiMatch MultiMatch { get; set;}

        [JsonProperty("script")]
        public Script Script { get; set;}

        [JsonProperty("range")]
        public Range Range { get; set;}

    }
}
