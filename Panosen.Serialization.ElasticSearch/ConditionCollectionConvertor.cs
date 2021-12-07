using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Panosen.Serialization.ElasticSearch
{
    public class ConditionCollectionConvertor : JsonConverter<ConditionCollection>
    {
        public override ConditionCollection ReadJson(JsonReader reader, Type objectType, ConditionCollection existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.StartObject:
                    {
                        Condition item = serializer.Deserialize<Condition>(reader);
                        return new ConditionCollection
                        {
                            ConditionList = new List<Condition> { item }
                        };
                    }

                case JsonToken.StartArray:
                    {
                        List<Condition> conditionList = serializer.Deserialize<List<Condition>>(reader);
                        return new ConditionCollection
                        {
                            ConditionList = conditionList
                        };
                    }

                default:
                    {
                        return null;
                    }
            }
        }
        public override void WriteJson(JsonWriter writer, ConditionCollection conditionCollection, JsonSerializer serializer)
        {
            if (conditionCollection == null || conditionCollection.ConditionList == null || conditionCollection.ConditionList.Count == 0)
            {
                return;
            }
            serializer.Serialize(writer, conditionCollection.ConditionList);
        }
    }
}
