using System.Text.Json;
using System.Text.Json.Serialization;

namespace TradingPlatform.Json
{
    public class JsonOptions
    {
        public readonly static JsonSerializerOptions WithEnumConversion = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }
}
