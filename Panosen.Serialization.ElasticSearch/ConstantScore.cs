using Newtonsoft.Json;
using System;

namespace Panosen.Serialization.ElasticSearch
{
    public class ConstantScore
    {
        [JsonProperty("filter")]
        public Filter Filter { get; set;}

        [JsonProperty("boost")]
        public int Boost { get; set;}
    }
}
