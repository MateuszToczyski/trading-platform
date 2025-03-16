using TradingPlatform.Model;
using TradingPlatform.Repository;

namespace TradingPlatform.Service
{
    public class LoginHandler
    {
        private readonly IGetAccountRepository getAccountRepository;

        public LoginHandler(IGetAccountRepository getAccountRepository)
        {
            this.getAccountRepository = getAccountRepository;
        }

        public Account Login(string username, string password)
        {
            Account account = getAccountRepository.GetAccount(username);

            if (account == null || !IsPasswordCorrect(account, password))
            {
                return null;
            }
            else
            {
                return account;
            }
        }

        private bool IsPasswordCorrect(Account account, string password)
        {
            string hashedPassword = account.HashedPassword;
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
