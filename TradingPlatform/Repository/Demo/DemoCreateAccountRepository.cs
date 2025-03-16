using System.Text.Json;
using TradingPlatform.Model;
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
            Account account = new Account(login, hashedPassword);
            fileWriter.WriteUserFile(login, JsonSerializer.Serialize(account));
        }
    }
}
