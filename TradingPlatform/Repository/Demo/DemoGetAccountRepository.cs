using System.Text.Json;
using TradingPlatform.Model;
using TradingPlatform.Model.Demo;
using TradingPlatform.Model.DTO;
using TradingPlatform.Service.Demo;

namespace TradingPlatform.Repository.Demo
{
    class DemoGetAccountRepository : IGetAccountRepository
    {
        private readonly FileReader fileReader;

        public DemoGetAccountRepository(FileReader fileReader)
        {
            this.fileReader = fileReader;
        }

        public Account GetAccount(string username)
        {
            string fileContent = fileReader.GetUserFileContent(username);

            if (fileContent == null)
            {
                return null;
            }
            else
            {
                AccountJson accountJson = JsonSerializer.Deserialize<AccountJson>(fileContent);
                return new DemoAccount(accountJson);
            }
        }
    }
}
