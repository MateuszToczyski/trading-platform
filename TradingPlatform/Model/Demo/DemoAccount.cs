using System.Collections.Generic;
using System.Linq;
using TradingPlatform.Model.DTO;
using TradingPlatform.Service.CashOperations;
using TradingPlatform.Service.Orders;

namespace TradingPlatform.Model.Demo
{
    public class DemoAccount : Account
    {
        public DemoAccount(string login, string hashedPassword) :
            base(login, hashedPassword, 0, new Dictionary<Instrument, int>()) { }

        public DemoAccount(AccountJson json) : base(
            json.Login,
            json.HashedPassword,
            json.CashBalance,
            json.OpenPositions.ToDictionary(entry => (Instrument)new DemoInstrument(entry.Key), entry => entry.Value)
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
                CashBalance -= orderValue;

                if (openPositions.ContainsKey(instrument))
                {
                    openPositions[instrument] = openPositions[instrument] += volume;
                }
                else
                {
                    openPositions.Add(instrument, volume);
                }

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

            if (!openPositions.ContainsKey(instrument) || openPositions[instrument] < volume)
            {
                return SellOrderResult.InsufficientPosition;
            }
            else
            {
                CashBalance += orderValue;
                openPositions[instrument] -= volume;

                if (openPositions[instrument] == 0)
                {
                    openPositions.Remove(instrument);
                }

                return SellOrderResult.Success;
            }
        }
    }
}
