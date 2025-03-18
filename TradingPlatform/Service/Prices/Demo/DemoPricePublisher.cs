using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TradingPlatform.Service.Prices.Demo
{
    // Wersja demonstracyjna - publikuje losowy ciąg cen, zaczynając od arbitralnie wybranych cen początkowych
    class DemoPricePublisher : PricePublisher
    {
        private readonly Random random = new Random();

        private readonly Dictionary<string, decimal> prices = new Dictionary<string, decimal>
        {
            { "KGHM", 150 },
            { "PKN Orlen", 70 },
            { "PZU", 100 }
        };

        public override void Start()
        {
            Thread thread = new Thread(UpdateAndPublishPricesLoop) { IsBackground = true };
            thread.Start();
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
            double randomMultiplier = 1 + 0.01 * (random.NextDouble() - 0.5);
            decimal newPrice = currentPrice * (decimal)randomMultiplier;
            return Math.Round(newPrice, 2);
        }
    }
}
