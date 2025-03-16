using TradingPlatform.Service.Accounts;
using TradingPlatform.Service.CashOperations;

namespace TradingPlatform.Factory
{
    public interface IFactory
    {
        AccountCreator GetAccountCreator();

        LoginHandler GetLoginHandler();

        DepositHandler GetDepositHandler();

        WithdrawalHandler GetWithdrawalHandler();
    }
}
