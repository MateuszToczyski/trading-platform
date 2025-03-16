using TradingPlatform.Model;
using TradingPlatform.Service.Accounts;

namespace TradingPlatform.Service.CashOperations
{
    public class DepositHandler
    {
        private readonly AccountUpdater accountUpdater;
        private readonly AmountValidator amountValidator;

        public DepositHandler(AccountUpdater accountUpdater, AmountValidator amountValidator)
        {
            this.accountUpdater = accountUpdater;
            this.amountValidator = amountValidator;
        }

        public DepositResult Deposit(Account account, string amount)
        {
            if (!amountValidator.IsAmountValid(amount))
            {
                return DepositResult.InvalidAmount;
            }

            DepositResult result = account.Deposit(decimal.Parse(amount));

            if (result == DepositResult.Success)
            {
                accountUpdater.UpdateAccount(account);
            }

            return result;
        }
    }

    public enum DepositResult
    {
        Success,
        InvalidAmount
    }
}
