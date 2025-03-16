using System.Text.Json.Serialization;
using TradingPlatform.Service.CashOperations;

namespace TradingPlatform.Model
{
    public class Account
    {
        [JsonInclude]
        public string Login { get; }

        [JsonInclude]
        public string HashedPassword { get; }

        [JsonInclude]
        public decimal CashBalance { get; private set; } = 0;

        public Account(string login, string hashedPassword)
        {
            Login = login;
            HashedPassword = hashedPassword;
        }

        public DepositResult Deposit(decimal amount)
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

        public WithdrawalResult Withdraw(decimal amount)
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
    }
}
