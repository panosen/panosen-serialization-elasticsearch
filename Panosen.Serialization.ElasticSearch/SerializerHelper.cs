using Newtonsoft.Json;
using System;

namespace Panosen.Serialization.ElasticSearch
{
    internal static class SerializerHelper
    {
        public static void WriteProperty(JsonWriter writer, string propertyName, string propertyValue, JsonSerializer serializer)
        {
            switch (serializer.NullValueHandling)
            {
                case NullValueHandling.Include:
                    {
                        writer.WritePropertyName(propertyName);
                        writer.WriteValue(propertyValue);
                    }
                    break;
                case NullValueHandling.Ignore:
                    {
                        if (propertyValue != null)
                        {
                            writer.WritePropertyName(propertyName);
                            writer.WriteValue(propertyValue);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public static void WriteProperty(JsonWriter writer, string propertyName, long? propertyValue, JsonSerializer serializer)
        {
            switch (serializer.NullValueHandling)
            {
                case NullValueHandling.Include:
                    {
                        writer.WritePropertyName(propertyName);
                        writer.WriteValue(propertyValue);
                    }
                    break;
                case NullValueHandling.Ignore:
                    {
                        if (propertyValue.HasValue)
                        {
                            writer.WritePropertyName(propertyName);
                            writer.WriteValue(propertyValue);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public static void WriteProperty(JsonWriter writer, string propertyName, bool? propertyValue, JsonSerializer serializer)
        {
            switch (serializer.NullValueHandling)
            {
                case NullValueHandling.Include:
                    {
                        writer.WritePropertyName(propertyName);
                        writer.WriteValue(propertyValue);
                    }
                    break;
                case NullValueHandling.Ignore:
                    {
                        if (propertyValue.HasValue)
                        {
                            writer.WritePropertyName(propertyName);
                            writer.WriteValue(propertyValue);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
