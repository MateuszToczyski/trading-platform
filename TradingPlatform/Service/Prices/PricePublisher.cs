using System.Collections.Generic;

namespace TradingPlatform.Service.Prices
{
    public abstract class PricePublisher
    {
        private readonly List<IPriceObserver> observers = new List<IPriceObserver>();

        public void AddObserver(IPriceObserver observer)
        {
            observers.Add(observer);
        }

        public abstract void Start();

        protected void PublishPrices(Dictionary<string, decimal> prices)
        {
            foreach (IPriceObserver observer in observers)
            {
                observer.HandlePricesPublished(prices);
            }
        }
    }
}
