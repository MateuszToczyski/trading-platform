namespace TradingPlatform.Model
{
    public class OpenPosition
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
