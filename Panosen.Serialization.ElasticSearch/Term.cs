using Newtonsoft.Json;
using System;

namespace Panosen.Serialization.ElasticSearch
{
    public class Term
    {
        [JsonProperty("name")]
        public string Name { get; set;}

        [JsonProperty("value")]
        public object Value { get; set;}

        [JsonProperty("boost")]
        public int Boost { get; set;}
    }
}
