using TradingPlatform.Model;
using TradingPlatform.Repository;

namespace TradingPlatform.Service.Accounts
{
    public class AccountUpdater
    {
        private readonly IUpdateAccountRepository updateAccountRepository;

        public AccountUpdater(IUpdateAccountRepository updateAccountRepository)
        {
            this.updateAccountRepository = updateAccountRepository;
        }

        public void UpdateAccount(Account account)
        {
            updateAccountRepository.UpdateAccount(account);
        }
    }
}
