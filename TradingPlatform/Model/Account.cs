using System.Collections.Generic;
using System.Linq;
using TradingPlatform.Service.CashOperations;
using TradingPlatform.Service.Orders;

namespace TradingPlatform.Model
{
    abstract public class Account
    {
        public string Login { get; }
        public string HashedPassword { get; }
        public decimal CashBalance { get; protected set; }
        
        public Dictionary<Instrument, int> OpenPositions
        {
            get
            {
                return openPositions.ToDictionary(entry => entry.Key, entry => entry.Value);
            }
        }

        protected readonly Dictionary<Instrument, int> openPositions;

        public Account(string login, string hashedPassword, decimal cashBalance, Dictionary<Instrument, int> openPositions)
        {
            Login = login;
            HashedPassword = hashedPassword;
            CashBalance = cashBalance;
            this.openPositions = openPositions;
        }

        abstract public DepositResult Deposit(decimal amount);

        abstract public WithdrawalResult Withdraw(decimal amount);

        abstract public BuyOrderResult BuyInstrument(Instrument instrument, int volume, decimal price);

        abstract public SellOrderResult SellInstrument(Instrument instrument, int volume, decimal price);
    }
}
