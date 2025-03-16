using System.Collections.Generic;
using TradingPlatform.Model;

namespace TradingPlatform.Repository.Demo
{
    class DemoInstrumentRepository : IInstrumentRepository
    {
        public List<Instrument> GetAllInstruments()
        {
            return new List<Instrument>
            {
                new Instrument("KGHM", InstrumentType.Stock),
            };
        }
    }
}
