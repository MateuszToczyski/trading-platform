using TradingPlatform.Model;
using TradingPlatform.Service.Accounts;

namespace TradingPlatform.Service.Orders
{
    public class OrderHandler
    {
        private readonly AccountUpdater accountUpdater;

        public OrderHandler(AccountUpdater accountUpdater)
        {
            this.accountUpdater = accountUpdater;
        }

        public BuyOrderResult PlaceBuyOrder(Account account, Instrument instrument, int volume, decimal price)
        {
            BuyOrderResult result = account.BuyInstrument(instrument, volume, price);

            if (result == BuyOrderResult.Success)
            {
                accountUpdater.UpdateAccount(account);
            }

            return result;
        }

        public SellOrderResult PlaceSellOrder(Account account, Instrument instrument, int volume, decimal price)
        {
            SellOrderResult result = account.SellInstrument(instrument, volume, price);

            if (result == SellOrderResult.Success)
            {
                accountUpdater.UpdateAccount(account);
            }

            return result;
        }
    }

    public enum BuyOrderResult
    {
        Success,
        InvalidVolume,
        InvalidPrice,
        InsufficientFunds
    }

    public enum SellOrderResult
    {
        Success,
        InvalidVolume,
        InvalidPrice,
        InsufficientPosition
    }
}
