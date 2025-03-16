using System.Collections.Generic;
using TradingPlatform.Model;

namespace TradingPlatform.Repository
{
    interface IInstrumentRepository
    {
        List<Instrument> GetAllInstruments();
    }
}
