using Newtonsoft.Json;
using System;

namespace Panosen.Serialization.ElasticSearch
{
    public class ScriptObject
    {
        [JsonProperty("inline")]
        public string Inline { get; set;}

        [JsonProperty("lang")]
        public string Lang { get; set;}
    }
}
