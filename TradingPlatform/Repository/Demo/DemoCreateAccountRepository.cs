using TradingPlatform.Model;
using TradingPlatform.Model.Demo;
using TradingPlatform.Model.DTO;
using TradingPlatform.Service.Demo;

namespace TradingPlatform.Repository.Demo
{
    public class DemoCreateAccountRepository : ICreateAccountRepository
    {
        private readonly FileWriter fileWriter;

        public DemoCreateAccountRepository(FileWriter fileWriter)
        {
            this.fileWriter = fileWriter;
        }

        public void CreateAccount(string login, string hashedPassword)
        {
            Account account = new DemoAccount(login, hashedPassword);
            AccountJson accountJson = new AccountJson(account);
            fileWriter.WriteUserFile(login, accountJson.ToJsonString());
        }
    }
}
