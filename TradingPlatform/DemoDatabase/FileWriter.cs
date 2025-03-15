using System.IO;

namespace TradingPlatform.DemoDatabase
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
