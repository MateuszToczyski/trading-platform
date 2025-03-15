using System.Text.Json;
using TradingPlatform.Model;

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
                return JsonSerializer.Deserialize<Account>(fileContent);
            }
        }
    }
}
