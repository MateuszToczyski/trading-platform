namespace TradingPlatform.Model
{
    abstract public class OpenPosition
    {
        public Instrument Instrument { get; }
        
        public int Volume { get; set; }

        public OpenPosition(Instrument instrument, int volume)
        {
            Instrument = instrument;
            Volume = volume;
        }
    }
}
