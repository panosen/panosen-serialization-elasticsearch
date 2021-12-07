using Newtonsoft.Json;
using System;

namespace Panosen.Serialization.ElasticSearch
{
    public class MatchPhrase
    {
        [JsonProperty("name")]
        public string Name { get; set;}

        [JsonProperty("query")]
        public string Query { get; set;}

        [JsonProperty("analyzer")]
        public string Analyzer { get; set;}

        [JsonProperty("slop")]
        public int Slop { get; set;}

        [JsonProperty("boost")]
        public int Boost { get; set;}
    }
}
