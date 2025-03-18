using System.Text.Json.Serialization;

namespace TradingPlatform.Model.DTO
{
    public class OpenPositionJson
    {
        [JsonInclude]
        public InstrumentJson Instrument { get; }

        [JsonInclude]
        public int Volume { get; }

        [JsonConstructor]
        public OpenPositionJson(InstrumentJson instrument, int volume)
        {
            Instrument = instrument;
            Volume = volume;
        }

        public OpenPositionJson(OpenPosition openPosition)
        {
            Instrument = new InstrumentJson(openPosition.Instrument);
            Volume = openPosition.Volume;
        }
    }
}
