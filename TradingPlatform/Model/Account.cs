using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TradingPlatform.Model
{
    public class Account
    {
        [JsonInclude]
        public string Login { get; }

        [JsonInclude]
        public string HashedPassword { get; }

        [JsonInclude]
        private List<decimal> cashOperations = new List<decimal>();

        public Account(string login, string hashedPassword)
        {
            Login = login;
            HashedPassword = hashedPassword;
        }

        public bool AddCashOperation(decimal amount)
        {
            if (GetBalance() + amount < 0)
            {
                return false;
            }
            else
            {
                cashOperations.Add(amount);
                return true;
            }
        }

        public decimal GetBalance()
        {
            decimal balance = 0;
            foreach (decimal amount in cashOperations)
            {
                balance += amount;
            }
            return balance;
        }
    }
}
