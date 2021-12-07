using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Panosen.Serialization.ElasticSearch
{
    public class MatchPhraseConverter : JsonConverter<MatchPhrase>
    {
        public override MatchPhrase ReadJson(JsonReader reader, Type objectType, MatchPhrase existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            MatchPhrase matchPhrase = new MatchPhrase();
            IEnumerable<JProperty> properties = serializer.Deserialize<JObject>(reader).Properties();
            if (properties.Count() > 0)
            {
                JProperty jProperty = properties.First();
                matchPhrase.Name = jProperty.Name;
                foreach (JProperty current in (jProperty.Value as JObject).Properties())
                {
                    string name = current.Name;
                    switch (name)
                    {
                        case "query":
                            matchPhrase.Query = Convert.ToString(current.Value);
                            break;
                        case "analyzer":
                            matchPhrase.Analyzer = Convert.ToString(current.Value);
                            break;
                        case "slop":
                            matchPhrase.Slop = Convert.ToInt32(current.Value);
                            break;
                        case "boost":
                            matchPhrase.Boost = Convert.ToInt32(current.Value);
                            break;
                        default:
                            break;
                    }
                }
            }
            return matchPhrase;
        }
        public override void WriteJson(JsonWriter writer, MatchPhrase matchPhrase, JsonSerializer serializer)
        {
            if (matchPhrase != null)
            {
                writer.WriteStartObject();
                writer.WritePropertyName(matchPhrase.Name);
                writer.WriteStartObject();
                writer.WritePropertyName("query");
                writer.WriteValue(matchPhrase.Query);
                if (matchPhrase.Analyzer != null)
                {
                    writer.WritePropertyName("analyzer");
                    writer.WriteValue(matchPhrase.Analyzer);
                }
                writer.WritePropertyName("slop");
                writer.WriteValue(matchPhrase.Slop);
                writer.WritePropertyName("boost");
                writer.WriteValue(matchPhrase.Boost);
                writer.WriteEndObject();
                writer.WriteEndObject();
            }
        }
    }
}
