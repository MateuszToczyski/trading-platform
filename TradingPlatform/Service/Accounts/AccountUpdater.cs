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

        public void UpdateAccount(Model.Account account)
        {
            updateAccountRepository.UpdateAccount(account);
        }
    }
}
