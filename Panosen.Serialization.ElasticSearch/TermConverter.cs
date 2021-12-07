using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Panosen.Serialization.ElasticSearch
{
    public class TermConverter : JsonConverter<Term>
    {
        public override Term ReadJson(JsonReader reader, Type objectType, Term existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Term term = new Term();
            IEnumerable<JProperty> properties = serializer.Deserialize<JObject>(reader).Properties();
            if (properties.Count() > 0)
            {
                JProperty jProperty = properties.First();
                term.Name = jProperty.Name;
                foreach (JProperty current in (jProperty.Value as JObject).Properties())
                {
                    string name = current.Name;
                    switch (name)
                    {
                        case "value":
                            term.Value = current.Value;
                            break;
                        case "boost":
                            term.Boost = Convert.ToInt32(current.Value);
                            break;
                        default:
                            break;
                    }
                }
            }
            return term;
        }

        public override void WriteJson(JsonWriter writer, Term term, JsonSerializer serializer)
        {
            if (term == null)
            {
                return;
            }
            writer.WriteStartObject();
            writer.WritePropertyName(term.Name);
            writer.WriteStartObject();
            writer.WritePropertyName("value");
            writer.WriteValue(term.Value);
            writer.WritePropertyName("boost");
            writer.WriteValue(term.Boost);
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
    }
}
