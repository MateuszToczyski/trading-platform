using System.IO;
using TradingPlatform.DemoDatabase;

namespace TradingPlatform.Repository.Demo
{
    class FileReader : FileHandler
    {
        public string GetUserFileContent(string login)
        {
            string path = GetUserFilePath(login);

            if (!File.Exists(path))
            {
                return null;
            }
            else
            {
                return File.ReadAllText(path);
            }
        }
    }
}
