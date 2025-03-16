using TradingPlatform.Model.DTO;
using TradingPlatform.Service.CashOperations;

namespace TradingPlatform.Model
{
    abstract public class Account
    {
        public string Login { get; }
        public string HashedPassword { get; }
        public decimal CashBalance { get; protected set; }

        public Account(string login, string hashedPassword)
        {
            Login = login;
            HashedPassword = hashedPassword;
        }

        public Account(AccountJson accountJson)
        {
            Login = accountJson.Login;
            HashedPassword = accountJson.HashedPassword;
            CashBalance = accountJson.CashBalance;
        }

        abstract public DepositResult Deposit(decimal amount);

        abstract public WithdrawalResult Withdraw(decimal amount);
    }
}
