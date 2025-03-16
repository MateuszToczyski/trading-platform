using System;
using System.IO;

namespace TradingPlatform.DemoDatabase
{
    public abstract class FileHandler
    {
        private readonly static string EXTENSION = ".json";
        private readonly static string DEMO_DB_PATH = "DemoDatabase";

        private readonly string basePath;
        private readonly string usersPath;

        public FileHandler()
        {
            basePath = ResolveSubDirectory(AppDomain.CurrentDomain.BaseDirectory, DEMO_DB_PATH);
            usersPath = ResolveSubDirectory(basePath, "Users");
        }

        protected string GetUserFilePath(string login)
        {
            return Path.Combine(basePath, usersPath, login + EXTENSION);
        }

        private string ResolveSubDirectory(string parentDirectory, string subDirectory)
        {
            string path = Path.Combine(parentDirectory, subDirectory);
            Directory.CreateDirectory(path); // metoda idempotentna - tworzy katalog tylko jeśli nie istnieje
            return path;
        }
    }
}
