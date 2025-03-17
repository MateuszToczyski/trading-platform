using System.Collections.Generic;
using TradingPlatform.Model;
using TradingPlatform.Model.Demo;

namespace TradingPlatform.Repository.Demo
{
    public class DemoInstrumentRepository : IInstrumentRepository
    {
        public List<Instrument> GetAllInstruments()
        {
            return new List<Instrument>
            {
                new DemoInstrument("KGHM", InstrumentType.Akcje),
                new DemoInstrument("PKN Orlen", InstrumentType.Akcje),
                new DemoInstrument("PZU 0727", InstrumentType.Obligacje),
            };
        }
    }
}
