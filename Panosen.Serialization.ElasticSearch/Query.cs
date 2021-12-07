using Newtonsoft.Json;
using System;

namespace Panosen.Serialization.ElasticSearch
{
    public class Query
    {
        [JsonProperty("bool")]
        public BoolQuery BoolQuery { get; set;}

    }
}
