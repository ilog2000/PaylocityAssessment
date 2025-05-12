using System;
using System.Globalization;

using Newtonsoft.Json;

namespace Api.Utils;

public class DecimalFormatConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return (objectType == typeof(decimal));
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        writer.WriteValue(string.Format(CultureInfo.InvariantCulture, "{0:N2}", value));
    }
}