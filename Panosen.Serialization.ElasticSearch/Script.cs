using Newtonsoft.Json;
using System;

namespace Panosen.Serialization.ElasticSearch
{
    public class Script
    {
        [JsonProperty("script")]
        public ScriptObject ScriptObject { get; set;}

        [JsonProperty("boost")]
        public int Boost { get; set;}
    }
}
