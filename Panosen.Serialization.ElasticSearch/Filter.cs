using Newtonsoft.Json;
using System;

namespace Panosen.Serialization.ElasticSearch
{
    public class Filter
    {
        [JsonProperty("terms")]
        public Terms Terms { get; set;}

        [JsonProperty("term")]
        public Term Term { get; set;}

        [JsonProperty("exists")]
        public Exists Exists { get; set;}

        [JsonProperty("match_phrase")]
        public MatchPhrase MatchPhrase { get; set;}

        [JsonProperty("bool")]
        public BoolQuery BoolQuery { get; set;}

        [JsonProperty("match")]
        public Match Match { get; set;}

        [JsonProperty("multi_match")]
        public MultiMatch MultiMatch { get; set;}

        [JsonProperty("constant_score")]
        public ConstantScore ConstantScore { get; set;}
    }
}
