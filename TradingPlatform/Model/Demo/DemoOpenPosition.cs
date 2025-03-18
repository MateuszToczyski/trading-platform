using TradingPlatform.Model.DTO;

namespace TradingPlatform.Model.Demo
{
    class DemoOpenPosition : OpenPosition
    {
        public DemoOpenPosition(Instrument instrument, int volume) : base(instrument, volume) { }

        public DemoOpenPosition(OpenPositionJson json) : base(new DemoInstrument(json.Instrument), json.Volume) { }
    }
}
