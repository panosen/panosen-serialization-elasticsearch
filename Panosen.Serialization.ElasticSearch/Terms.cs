using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Panosen.Serialization.ElasticSearch
{
    public class Terms
    {
        [JsonProperty("name")]
        public string Name { get; set;}

        [JsonProperty("values")]
        public List<object> Values { get; set;}

        [JsonProperty("boost")]
        public int Boost { get; set;}
    }
}
