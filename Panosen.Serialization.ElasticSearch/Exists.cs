using Newtonsoft.Json;
using System;

namespace Panosen.Serialization.ElasticSearch
{
    public class Exists
    {
        [JsonProperty("field")]
        public string Field { get; set;}

        [JsonProperty("boost")]
        public int Boost { get; set;}
    }
}
