using System.Collections.Generic;
using TradingPlatform.Model;

namespace TradingPlatform.Repository
{
    public interface IInstrumentRepository
    {
        List<Instrument> GetAllInstruments();
    }
}
