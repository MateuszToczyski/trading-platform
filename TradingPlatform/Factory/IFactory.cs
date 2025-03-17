using TradingPlatform.Service.Accounts;
using TradingPlatform.Service.CashOperations;
using TradingPlatform.Service.Instruments;
using TradingPlatform.Service.Prices;

namespace TradingPlatform.Factory
{
    public interface IFactory
    {
        AccountCreator GetAccountCreator();

        LoginHandler GetLoginHandler();

        DepositHandler GetDepositHandler();

        WithdrawalHandler GetWithdrawalHandler();

        InstrumentProvider GetInstrumentProvider();

        PricePublisher GetPricePublisher();
    }
}
