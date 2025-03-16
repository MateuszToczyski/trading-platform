namespace TradingPlatform.Model.Demo
{
    class DemoInstrument : Instrument
    {
        public override string GetFullName()
        {
            return base.GetFullName() + " [DEMO]";
        }
    }
}
