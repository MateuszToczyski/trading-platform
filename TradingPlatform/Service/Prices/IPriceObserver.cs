using System.Collections.Generic;

namespace TradingPlatform.Service.Prices
{
    public interface IPriceObserver
    {
        void HandlePricesPublished(Dictionary<string, decimal> prices);
    }
}
