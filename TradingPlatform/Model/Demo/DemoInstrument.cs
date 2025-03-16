namespace TradingPlatform.Model.Demo
{
    public class DemoInstrument : Instrument
    {
        public DemoInstrument(string name, InstrumentType type) : base(name, type)
        {
        }

        public override string GetFullName()
        {
            return base.GetFullName() + " [DEMO]";
        }
    }
}
