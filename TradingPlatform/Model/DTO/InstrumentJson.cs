using System.Text.Json;
using System.Text.Json.Serialization;

namespace TradingPlatform.Model.DTO
{
    public class InstrumentJson
    {
        [JsonInclude]
        public string Name { get; }

        [JsonInclude]
        public InstrumentType Type { get; }

        [JsonConstructor]
        public InstrumentJson(string name, InstrumentType type)
        {
            Name = name;
            Type = type;
        }

        public InstrumentJson(Instrument instrument)
        {
            Name = instrument.Name;
            Type = instrument.Type;
        }

        public string ToJsonString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
