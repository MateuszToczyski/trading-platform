using TradingPlatform.Repository;
using TradingPlatform.Repository.Demo;
using TradingPlatform.Service.Accounts;
using TradingPlatform.Service.CashOperations;
using TradingPlatform.Service.Demo;
using TradingPlatform.Service.Instruments;
using TradingPlatform.Service.Prices;
using TradingPlatform.Service.Prices.Demo;

namespace TradingPlatform.Factory
{
    public class DemoFactory : IFactory
    {
        private readonly AmountValidator amountValidator = new AmountValidator();
        private readonly FileWriter fileWriter = new FileWriter();

        private readonly IGetAccountRepository getAccountRepository;
        private readonly ICreateAccountRepository createAccountRepository;
        private readonly IUpdateAccountRepository updateAccountRepository;
        private readonly IInstrumentRepository instrumentRepository;

        private readonly AccountUpdater accountUpdater;

        public DemoFactory()
        {
            getAccountRepository = new DemoGetAccountRepository(new FileReader());
            createAccountRepository = new DemoCreateAccountRepository(fileWriter);
            updateAccountRepository = new DemoUpdateAccountRepository(fileWriter);
            instrumentRepository = new DemoInstrumentRepository();
            accountUpdater = new AccountUpdater(updateAccountRepository);
        }

        public AccountCreator GetAccountCreator()
        {
            return new AccountCreator(createAccountRepository, getAccountRepository, new LoginValidator(), new PasswordValidator());
        }

        public LoginHandler GetLoginHandler()
        {
            return new LoginHandler(getAccountRepository);
        }

        public DepositHandler GetDepositHandler()
        {
            return new DepositHandler(accountUpdater, amountValidator);
        }

        public WithdrawalHandler GetWithdrawalHandler()
        {
            return new WithdrawalHandler(accountUpdater, amountValidator);
        }

        public InstrumentProvider GetInstrumentProvider()
        {
            return new InstrumentProvider(instrumentRepository);
        }

        public PricePublisher GetPricePublisher()
        {
            return new DemoPricePublisher();
        }
    }
}
