using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Panosen.Serialization.ElasticSearch
{
    public class RangeConvertor : JsonConverter<Range>
    {
        public override Range ReadJson(JsonReader reader, Type objectType, Range existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Range range = new Range();
            IEnumerable<JProperty> properties = serializer.Deserialize<JObject>(reader).Properties();
            if (properties.Count() > 0)
            {
                JProperty jProperty = properties.First();
                range.Name = jProperty.Name;
                foreach (JProperty current in (jProperty.Value as JObject).Properties())
                {
                    string name = current.Name;
                    switch (name)
                    {
                        case "to":
                            range.To = new long?(Convert.ToInt64(current.Value));
                            break;
                        case "lte":
                            range.LessEqualThan = new long?(Convert.ToInt64(current.Value));
                            break;
                        case "gte":
                            range.GreateEqualThan = new long?(Convert.ToInt64(current.Value));
                            break;
                        case "gt":
                            range.GreaterThan = new long?(Convert.ToInt64(current.Value));
                            break;
                        case "include_lower":
                            range.IncludeLower = new bool?(Convert.ToBoolean(current.Value));
                            break;
                        case "boost":
                            range.Boost = new int?(Convert.ToInt32(current.Value));
                            break;
                        case "include_upper":
                            range.IncludeUpper = new bool?(Convert.ToBoolean(current.Value));
                            break;
                        case "from":
                            range.From = new long?(Convert.ToInt64(current.Value));
                            break;
                        default:
                            break;
                    }
                }
            }
            return range;
        }

        public override void WriteJson(JsonWriter writer, Range range, JsonSerializer serializer)
        {
            if (range == null)
            {
                return;
            }
            writer.WriteStartObject();
            writer.WritePropertyName(range.Name);
            writer.WriteStartObject();
            SerializerHelper.WriteProperty(writer, "gt", range.GreaterThan, serializer);
            SerializerHelper.WriteProperty(writer, "gte", range.GreateEqualThan, serializer);
            SerializerHelper.WriteProperty(writer, "lt", range.LessThan, serializer);
            SerializerHelper.WriteProperty(writer, "lte", range.LessEqualThan, serializer);
            SerializerHelper.WriteProperty(writer, "from", range.From, serializer);
            SerializerHelper.WriteProperty(writer, "to", range.To, serializer);
            SerializerHelper.WriteProperty(writer, "include_lower", range.IncludeLower, serializer);
            SerializerHelper.WriteProperty(writer, "include_upper", range.IncludeUpper, serializer);
            SerializerHelper.WriteProperty(writer, "boost", range.Boost, serializer);
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
    }
}
