using TradingPlatform.DemoDatabase;
using TradingPlatform.Repository;
using TradingPlatform.Repository.Demo;
using TradingPlatform.Service;

namespace TradingPlatform.Factory
{
    public class DemoFactory : IFactory
    {
        private readonly LoginValidator loginValidator = new LoginValidator();
        private readonly PasswordValidator passwordValidator = new PasswordValidator();

        private readonly FileReader fileReader = new FileReader();
        private readonly FileWriter fileWriter = new FileWriter();

        private readonly IGetAccountRepository getAccountRepository;
        private readonly ICreateAccountRepository createAccountRepository;

        private readonly AccountCreator accountCreator;
        private readonly LoginHandler loginHandler;

        public DemoFactory()
        {
            getAccountRepository = new DemoGetAccountRepository(fileReader);
            createAccountRepository = new DemoCreateAccountRepository(fileWriter);
            accountCreator = new AccountCreator(createAccountRepository, getAccountRepository, loginValidator, passwordValidator);
            loginHandler = new LoginHandler(getAccountRepository);
        }

        public AccountCreator GetAccountCreator()
        {
            return accountCreator;
        }

        public LoginHandler GetLoginHandler()
        {
            return loginHandler;
        }
    }
}
