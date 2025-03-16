using TradingPlatform.Model.DTO;
using TradingPlatform.Service.CashOperations;

namespace TradingPlatform.Model.Demo
{
    public class DemoAccount : Account
    {
        public DemoAccount(string login, string hashedPassword) : base(login, hashedPassword) { }

        public DemoAccount(AccountJson accountJson) : base(accountJson) { }

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
    }
}
