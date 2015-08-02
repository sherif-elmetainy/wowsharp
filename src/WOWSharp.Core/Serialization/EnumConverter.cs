using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WOWSharp.Core.Serialization
{
    public class EnumConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType.IsEnumeration())
                return true;
            objectType = Nullable.GetUnderlyingType(objectType);
            return objectType != null && objectType.IsEnumeration();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var isNullable = objectType.IsNullable();
            var type = isNullable ? Nullable.GetUnderlyingType(objectType) : objectType;

            try
            {
                if (reader.TokenType == JsonToken.String)
                {
                    var enumText = reader.Value.ToString();
                    return EnumHelper.StringToEnum(type, enumText);
                }
                if (reader.TokenType == JsonToken.Integer)
                {
                    return Convert.ChangeType(reader.Value, typeof(int), CultureInfo.InvariantCulture);
                }
            }
            catch(Exception ex)
            {
                throw new JsonSerializationException($"Error converting value {reader.Value} to type {objectType}.", ex);
            }
            throw new JsonSerializationException($"Error converting value {reader.Value} to type {objectType}.");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            writer.WriteValue(EnumHelper.EnumToString(value));
        }
    }
}
