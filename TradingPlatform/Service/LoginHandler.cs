using TradingPlatform.Repository;

namespace TradingPlatform.Service
{
    class LoginHandler
    {
        private readonly ILoginRepository loginRepository;

        public LoginHandler(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        LoginResult Login(string username, string password)
        {
            return loginRepository.Login(username, password);
        }
    }

    enum LoginResult
    {
        Success,
        Failure
    }
}
