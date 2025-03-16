using TradingPlatform.Service;

namespace TradingPlatform.Factory
{
    public interface IFactory
    {
        AccountCreator GetAccountCreator();

        LoginHandler GetLoginHandler();
    }
}
