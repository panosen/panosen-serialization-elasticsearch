using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Panosen.Serialization.ElasticSearch
{
    public class Ids
    {
        [JsonProperty("values")]
        public List<object> Values { get; set;}

        [JsonProperty("boost")]
        public int Boost { get; set;}
    }
}
