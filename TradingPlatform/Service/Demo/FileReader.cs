using System.IO;

namespace TradingPlatform.Service.Demo
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
