using TradingPlatform.Model;
using TradingPlatform.Service.Accounts;

namespace TradingPlatform.Service.CashOperations
{
    public class WithdrawalHandler
    {
        private readonly AccountUpdater accountUpdater;
        private readonly AmountValidator amountValidator;

        public WithdrawalHandler(AccountUpdater accountUpdater, AmountValidator amountValidator)
        {
            this.accountUpdater = accountUpdater;
            this.amountValidator = amountValidator;
        }

        public WithdrawalResult Withdraw(Account account, string amount)
        {
            if (!amountValidator.IsAmountValid(amount))
            {
                return WithdrawalResult.InvalidAmount;
            }
            else
            {
                WithdrawalResult result = account.Withdraw(decimal.Parse(amount));

                if (result == WithdrawalResult.Success)
                {
                    accountUpdater.UpdateAccount(account);
                }

                return result;
            }
        }
    }

    public enum WithdrawalResult
    {
        Success,
        InvalidAmount,
        InsufficientFunds
    }
}
