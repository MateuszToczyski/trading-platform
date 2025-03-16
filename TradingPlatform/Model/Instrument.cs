namespace TradingPlatform.Model
{
    public class Instrument
    {
        public string Name { get; }
        public InstrumentType Type { get; }
    }

    public enum InstrumentType
    {
        Stock,
        Bond
    }
}
