using TradingPlatform.Repository;
using TradingPlatform.Repository.Demo;
using TradingPlatform.Service.Accounts;
using TradingPlatform.Service.CashOperations;
using TradingPlatform.Service.Demo;

namespace TradingPlatform.Factory
{
    public class DemoFactory : IFactory
    {
        private readonly LoginValidator loginValidator = new LoginValidator();
        private readonly PasswordValidator passwordValidator = new PasswordValidator();
        private readonly AmountValidator amountValidator = new AmountValidator();

        private readonly FileReader fileReader = new FileReader();
        private readonly FileWriter fileWriter = new FileWriter();

        private readonly IGetAccountRepository getAccountRepository;
        private readonly ICreateAccountRepository createAccountRepository;
        private readonly IUpdateAccountRepository updateAccountRepository;

        private readonly AccountCreator accountCreator;
        private readonly AccountUpdater accountUpdater;
        private readonly LoginHandler loginHandler;
        private readonly DepositHandler depositHandler;
        private readonly WithdrawalHandler withdrawalHandler;

        public DemoFactory()
        {
            getAccountRepository = new DemoGetAccountRepository(fileReader);
            createAccountRepository = new DemoCreateAccountRepository(fileWriter);
            updateAccountRepository = new DemoUpdateAccountRepository(fileWriter);

            accountCreator = new AccountCreator(createAccountRepository, getAccountRepository, loginValidator, passwordValidator);
            loginHandler = new LoginHandler(getAccountRepository);
            accountUpdater = new AccountUpdater(updateAccountRepository);
            depositHandler = new DepositHandler(accountUpdater, amountValidator);
            withdrawalHandler = new WithdrawalHandler(accountUpdater, amountValidator);
        }

        public AccountCreator GetAccountCreator()
        {
            return accountCreator;
        }

        public LoginHandler GetLoginHandler()
        {
            return loginHandler;
        }

        public DepositHandler GetDepositHandler()
        {
            return depositHandler;
        }

        public WithdrawalHandler GetWithdrawalHandler()
        {
            return withdrawalHandler;
        }
    }
}
