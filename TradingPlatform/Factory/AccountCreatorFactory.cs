using TradingPlatform.DemoDatabase;
using TradingPlatform.Repository;
using TradingPlatform.Repository.Demo;
using TradingPlatform.Service;

namespace TradingPlatform.Factory
{
    public class AccountCreatorFactory : IFactory<AccountCreator>
    {
        public AccountCreator Create()
        {
            LoginValidator loginValidator = new LoginValidator();
            PasswordValidator passwordValidator = new PasswordValidator();

            FileReader fileReader = new FileReader();
            FileWriter fileWriter = new FileWriter();
            
            ICreateAccountRepository createAccountRepository = new DemoCreateAccountRepository(fileWriter);
            IGetAccountRepository getAccountRepository = new DemoGetAccountRepository(fileReader);
            
            return new AccountCreator(createAccountRepository, getAccountRepository, loginValidator, passwordValidator);
        }
    }
}
