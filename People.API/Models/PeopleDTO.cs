using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace People.API.Models
{
    public partial class PeopleDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("age")]
        public long Age { get; set; }

        [JsonProperty("pets")]
        public Pet[] Pets { get; set; }
    }

    public partial class Pet
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }
    }

    public enum TypeEnum { Cat, Dog, Fish };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Cat":
                    return TypeEnum.Cat;
                case "Dog":
                    return TypeEnum.Dog;
                case "Fish":
                    return TypeEnum.Fish;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.Cat:
                    serializer.Serialize(writer, "Cat");
                    return;
                case TypeEnum.Dog:
                    serializer.Serialize(writer, "Dog");
                    return;
                case TypeEnum.Fish:
                    serializer.Serialize(writer, "Fish");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}
