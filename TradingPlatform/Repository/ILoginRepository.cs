using TradingPlatform.Service;

namespace TradingPlatform.Repository
{
    interface ILoginRepository
    {
        LoginResult Login(string login, string password);
    }
}
