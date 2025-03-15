using TradingPlatform.Model;

namespace TradingPlatform.Repository
{
    public interface IGetAccountRepository
    {
        Account GetAccount(string login);
    }
}
