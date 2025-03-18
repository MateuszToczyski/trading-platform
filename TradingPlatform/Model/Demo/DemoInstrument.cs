using TradingPlatform.Model.DTO;

namespace TradingPlatform.Model.Demo
{
    public class DemoInstrument : Instrument
    {
        public DemoInstrument(string name, InstrumentType type) : base(name, type) { }

        public DemoInstrument(InstrumentJson json) : base(json.Name, json.Type) { }

        public override string GetFullName()
        {
            return $"{base.GetFullName()} [DEMO]";
        }
    }
}
