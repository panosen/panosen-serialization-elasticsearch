using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Panosen.Serialization.ElasticSearch
{
    public class MatchConverter : JsonConverter<Match>
    {
        public override Match ReadJson(JsonReader reader, Type objectType, Match existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Match match = new Match();
            IEnumerable<JProperty> source = serializer.Deserialize<JObject>(reader).Properties();
            if (source.Count() == 0)
            {
                return match;
            }

            JProperty jProperty = source.First();
            match.Name = jProperty.Name;
            if (jProperty.Value is JObject)
            {
                using (IEnumerator<JProperty> enumerator = (jProperty.Value as JObject).Properties().GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        JProperty current = enumerator.Current;
                        string name = current.Name;

                        switch (name)
                        {
                            case "max_expansions":
                                match.MaxExpansions = new int?(Convert.ToInt32(current.Value));
                                break;
                            case "minimum_should_match":
                                match.MinimumShouldMatch = Convert.ToString(current.Value);
                                break;
                            case "fuzzy_transpositions":
                                match.FuzzyTranspositions = new bool?(Convert.ToBoolean(current.Value));
                                break;
                            case "lenient":
                                match.Lenient = new bool?(Convert.ToBoolean(current.Value));
                                break;
                            case "zero_terms_query":
                                match.ZeroTermsQuery = Convert.ToString(current.Value);
                                break;
                            case "analyzer":
                                match.Analyzer = Convert.ToString(current.Value);
                                break;
                            case "auto_generate_synonyms_phrase_query":
                                match.AutoGenerateSynonymsPhraseQuery = new bool?(Convert.ToBoolean(current.Value));
                                break;
                            case "prefix_length":
                                match.PrefixLength = new int?(Convert.ToInt32(current.Value));
                                break;
                            case "operator":
                                match.Operator = Convert.ToString(current.Value);
                                break;
                            case "boost":
                                match.Boost = new int?(Convert.ToInt32(current.Value));
                                break;
                            case "query":
                                match.Query = Convert.ToString(current.Value);
                                break;
                            default:
                                break;
                        }
                    }
                    return match;
                }
            }
            if (jProperty.Value is JValue)
            {
                JValue jValue = jProperty.Value as JValue;
                match.Query = Extensions.Value<string>(jValue);
            }
            return match;
        }

        public override void WriteJson(JsonWriter writer, Match match, JsonSerializer serializer)
        {
            if (match != null)
            {
                writer.WriteStartObject();
                writer.WritePropertyName(match.Name);
                writer.WriteStartObject();
                SerializerHelper.WriteProperty(writer, "query", match.Query, serializer);
                SerializerHelper.WriteProperty(writer, "operator", match.Operator, serializer);
                SerializerHelper.WriteProperty(writer, "analyzer", match.Analyzer, serializer);
                string arg_83_1 = "prefix_length";
                int? num = match.PrefixLength;
                SerializerHelper.WriteProperty(writer, arg_83_1, num.HasValue ? new long?((long)num.GetValueOrDefault()) : null, serializer);
                string arg_B7_1 = "max_expansions";
                num = match.MaxExpansions;
                SerializerHelper.WriteProperty(writer, arg_B7_1, num.HasValue ? new long?((long)num.GetValueOrDefault()) : null, serializer);
                SerializerHelper.WriteProperty(writer, "minimum_should_match", match.MinimumShouldMatch, serializer);
                SerializerHelper.WriteProperty(writer, "fuzzy_transpositions", match.FuzzyTranspositions, serializer);
                SerializerHelper.WriteProperty(writer, "lenient", match.Lenient, serializer);
                SerializerHelper.WriteProperty(writer, "zero_terms_query", match.ZeroTermsQuery, serializer);
                SerializerHelper.WriteProperty(writer, "auto_generate_synonyms_phrase_query", match.AutoGenerateSynonymsPhraseQuery, serializer);
                string arg_145_1 = "boost";
                num = match.Boost;
                SerializerHelper.WriteProperty(writer, arg_145_1, num.HasValue ? new long?((long)num.GetValueOrDefault()) : null, serializer);
                writer.WriteEndObject();
                writer.WriteEndObject();
            }
        }
    }
}
