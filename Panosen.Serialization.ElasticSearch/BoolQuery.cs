using Newtonsoft.Json;
using System;

namespace Panosen.Serialization.ElasticSearch
{
    public class BoolQuery
    {
        [JsonProperty("must")]
        public ConditionCollection Musts { get; set;}

        [JsonProperty("filter")]
        public ConditionCollection Filter { get; set;}

        [JsonProperty("should")]
        public ConditionCollection Shoulds { get; set;}

        [JsonProperty("disable_coord")]
        public bool? DisableCoord { get; set;}

        [JsonProperty("adjust_pure_negative")]
        public bool? AdjustPureNegative { get; set;}

        [JsonProperty("boost")]
        public int? Boost { get; set;}
    }
}
