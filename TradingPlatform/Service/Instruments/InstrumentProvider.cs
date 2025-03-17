using System.Collections.Generic;
using TradingPlatform.Model;
using TradingPlatform.Repository;

namespace TradingPlatform.Service.Instruments
{
    public class InstrumentProvider
    {
        private readonly IInstrumentRepository instrumentRepository;

        public InstrumentProvider(IInstrumentRepository instrumentRepository)
        {
            this.instrumentRepository = instrumentRepository;
        }

        public List<Instrument> GetAllInstruments()
        {
            return instrumentRepository.GetAllInstruments();
        }
    }
}
