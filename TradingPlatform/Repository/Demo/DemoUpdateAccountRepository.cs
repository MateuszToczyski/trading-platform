using System.Text.Json;
using TradingPlatform.Model;
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
            string accountJson = JsonSerializer.Serialize(account);
            fileWriter.WriteUserFile(account.Login, accountJson);
        }
    }
}
