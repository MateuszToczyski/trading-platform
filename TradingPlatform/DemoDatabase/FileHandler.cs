using System;
using System.IO;

namespace TradingPlatform.DemoDatabase
{
    public abstract class FileHandler
    {
        private readonly static string EXTENSION = ".json";
        private readonly static string DB_PATH = "DemoDatabase";
        private readonly static string USERS_PATH = "Users";

        private readonly string basePath;

        public FileHandler()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = Path.Combine(baseDirectory, DB_PATH);
            basePath = Path.GetFullPath(relativePath);
        }

        protected string GetUserFilePath(string login)
        {
            return Path.Combine(basePath, USERS_PATH, login + EXTENSION);
        }
    }
}
