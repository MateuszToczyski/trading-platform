using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TradingPlatform.Service.Prices.Demo
{
    // Wersja demonstracyjna - publikuje losowy ciąg cen, zaczynając od arbitralnie wybranych cen początkowych
    class DemoPricePublisher : PricePublisher
    {
        private readonly Dictionary<string, decimal> prices = new Dictionary<string, decimal>
        {
            { "KGHM", 150 },
            //{ "PKN Orlen", 70 },
            //{ "PZU 0727", 100 }
        };

        public override void Start()
        {
            Thread workerThread = new Thread(UpdateAndPublishPricesLoop) { IsBackground = true };
            workerThread.Start();
        }

        private void UpdateAndPublishPricesLoop()
        {
            while (true)
            {
                UpdatePrices();
                PublishPrices(prices);
                Thread.Sleep(1000);
            }
        }

        private void UpdatePrices()
        {
            foreach (string instrument in prices.Keys.ToList())
            {
                prices[instrument] = GetNewPrice(prices[instrument]);
            }
        }

        private decimal GetNewPrice(decimal currentPrice)
        {
            double randomValue = new Random().NextDouble() - 0.5;
            double changeFactor = 1 + 0.01 * randomValue;
            return currentPrice * (decimal) changeFactor;
        }
    }
}
