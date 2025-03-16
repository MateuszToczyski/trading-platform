namespace TradingPlatform.Model
{
    public class Instrument
    {
        public string Name { get; }
        public InstrumentType Type { get; }

        public Instrument(string name, InstrumentType type)
        {
            Name = name;
            Type = type;
        }

        public virtual string GetFullName()
        {
            return $"{Name} ({Type})";
        }
    }

    public enum InstrumentType
    {
        Akcje,
        Obligacje
    }
}
