using Newtonsoft.Json;
using System;

namespace Panosen.Serialization.ElasticSearch
{
    public class Request
    {
        [JsonProperty("query")]
        public Query Query { get; set;}
    }
}
