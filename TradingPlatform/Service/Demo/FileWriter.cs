using System.IO;

namespace TradingPlatform.Service.Demo
{
    public class FileWriter : FileHandler
    {
        public void WriteUserFile(string login, string fileContent)
        {
            string path = GetUserFilePath(login);
            File.WriteAllText(path, fileContent);
        }
    }
}
