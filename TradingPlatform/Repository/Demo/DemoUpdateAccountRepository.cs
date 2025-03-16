using TradingPlatform.Model;
using TradingPlatform.Model.DTO;
using TradingPlatform.Service.Demo;

namespace TradingPlatform.Repository.Demo
{
    public class DemoUpdateAccountRepository : IUpdateAccountRepository
    {
        private readonly FileWriter fileWriter;

        public DemoUpdateAccountRepository(FileWriter fileWriter)
        {
            this.fileWriter = fileWriter;
        }

        public void UpdateAccount(Account account)
        {
            AccountJson accountJson = new AccountJson(account);
            fileWriter.WriteUserFile(account.Login, accountJson.ToJsonString());
        }
    }
}
