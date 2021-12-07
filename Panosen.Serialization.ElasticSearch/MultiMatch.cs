using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Panosen.Serialization.ElasticSearch
{
    public class MultiMatch
    {
        [JsonProperty("query")]
        public string Query { get; set;}

        [JsonProperty("fields")]
        public List<string> Fields { get; set;}

        [JsonProperty("type")]
        public string Type { get; set;}

        [JsonProperty("operator")]
        public string Operator { get; set;}

        [JsonProperty("analyzer")]
        public string Analyzer { get; set;}

        [JsonProperty("slop")]
        public int Slop { get; set;}

        [JsonProperty("prefix_length")]
        public int PrefixLength { get; set;}

        [JsonProperty("max_expansions")]
        public int MaxExpansions { get; set;}

        [JsonProperty("minimum_should_match")]
        public string MinimumShouldMatch { get; set;}

        [JsonProperty("tie_breaker")]
        public double TieBreaker { get; set;}

        [JsonProperty("lenient")]
        public bool Lenient { get; set;}

        [JsonProperty("zero_terms_query")]
        public string ZeroTermsQuery { get; set;}

        [JsonProperty("boost")]
        public int Boost { get; set;}
    }
}
