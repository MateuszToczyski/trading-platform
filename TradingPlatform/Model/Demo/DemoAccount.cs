using System.Collections.Generic;
using TradingPlatform.Model.DTO;
using TradingPlatform.Service.CashOperations;
using TradingPlatform.Service.Orders;

namespace TradingPlatform.Model.Demo
{
    public class DemoAccount : Account
    {
        public DemoAccount(string login, string hashedPassword) :
            base(login, hashedPassword, 0, new List<OpenPosition>()) { }

        public DemoAccount(AccountJson json) : base(
            json.Login,
            json.HashedPassword,
            json.CashBalance,
            json.OpenPositions.ConvertAll(op => (OpenPosition) new DemoOpenPosition(op))
        ) { }

        // Wersja demonstracyjna - brak obsugi dostawców płatności, kont bankowych itp.
        override public DepositResult Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                return DepositResult.InvalidAmount;
            }
            else
            {
                CashBalance += amount;
                return DepositResult.Success;
            }
        }

        // Wersja demonstracyjna - brak obsugi dostawców płatności, kont bankowych itp.
        override public WithdrawalResult Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                return WithdrawalResult.InvalidAmount;
            }
            else if (CashBalance < amount)
            {
                return WithdrawalResult.InsufficientFunds;
            }
            else
            {
                CashBalance -= amount;
                return WithdrawalResult.Success;
            }
        }

        public override BuyOrderResult BuyInstrument(Instrument instrument, int volume, decimal price)
        {
            if (volume <= 0)
            {
                return BuyOrderResult.InvalidVolume;
            }
            else if (price <= 0)
            {
                return BuyOrderResult.InvalidPrice;
            }

            decimal orderValue = volume * price;

            if (orderValue > CashBalance)
            {
                return BuyOrderResult.InsufficientFunds;
            }
            else
            {
                HandleBuyOperation(instrument, volume, orderValue);
                return BuyOrderResult.Success;
            }
        }

        public override SellOrderResult SellInstrument(Instrument instrument, int volume, decimal price)
        {
            if (volume <= 0)
            {
                return SellOrderResult.InvalidVolume;
            }
            else if (price <= 0)
            {
                return SellOrderResult.InvalidPrice;
            }

            decimal orderValue = volume * price;

            if (openPositions.Contains(openPositions.Find(x => x.Instrument.Name == instrument.Name)))
            {
                return HandleSellOperation(instrument, volume, orderValue);
            }
            else
            {
                return SellOrderResult.InsufficientPosition;
            }
        }

        private void HandleBuyOperation(Instrument instrument, int volume, decimal orderValue)
        {
            CashBalance -= orderValue;

            if (openPositions.Contains(openPositions.Find(x => x.Instrument.Name == instrument.Name)))
            {
                openPositions.Find(x => x.Instrument == instrument).Volume += volume;
            }
            else
            {
                openPositions.Add(new DemoOpenPosition(instrument, volume));
            }
        }

        private SellOrderResult HandleSellOperation(Instrument instrument, int volume, decimal orderValue)
        {
            OpenPosition position = openPositions.Find(x => x.Instrument.Name == instrument.Name);

            if (position.Volume < volume)
            {
                return SellOrderResult.InsufficientPosition;
            }
            else
            {
                CashBalance += orderValue;
                position.Volume -= volume;
                if (position.Volume == 0)
                {
                    openPositions.Remove(position);
                }
                return SellOrderResult.Success;
            }
        }
    }
}
