using TradingPlatform.Model;
using TradingPlatform.Repository;

namespace TradingPlatform.Service.Accounts
{
    class AccountGetter
    {
        private readonly IGetAccountRepository getAccountRepository;

        public AccountGetter(IGetAccountRepository getAccountRepository)
        {
            this.getAccountRepository = getAccountRepository;
        }

        public Account GetAccount(string login)
        {
            return getAccountRepository.GetAccount(login);
        }
    }
}
