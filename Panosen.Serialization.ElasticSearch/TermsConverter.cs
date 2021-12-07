using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Panosen.Serialization.ElasticSearch
{
    public class TermsConverter : JsonConverter<Terms>
    {
        public override Terms ReadJson(JsonReader reader, Type objectType, Terms existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Terms terms = new Terms();
            List<JProperty> properties = serializer.Deserialize<JObject>(reader).Properties().ToList();
            if (properties.Count > 0)
            {
                JProperty jProperty = properties[0];
                terms.Name = jProperty.Name;
                terms.Values = jProperty.Value.Select(v=>v.Value<object>()).ToList();
            }
            if (properties.Count > 1)
            {
                terms.Boost = Extensions.Value<int>(properties[1].Value);
            }
            return terms;
        }

        public override void WriteJson(JsonWriter writer, Terms terms, JsonSerializer serializer)
        {
            if (terms == null)
            {
                return;
            }

            writer.WriteStartObject();
            if (terms.Values != null)
            {
                writer.WritePropertyName(terms.Name);
                writer.WriteStartArray();
                foreach (object current in terms.Values)
                {
                    writer.WriteValue(current);
                }
                writer.WriteEndArray();
            }
            writer.WritePropertyName("boost");
            writer.WriteValue(terms.Boost);
            writer.WriteEndObject();
        }
    }
}
