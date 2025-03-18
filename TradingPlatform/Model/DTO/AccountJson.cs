using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TradingPlatform.Model.DTO
{
    public class AccountJson
    {
        [JsonInclude]
        public string Login { get; }

        [JsonInclude]
        public string HashedPassword { get; }

        [JsonInclude]
        public decimal CashBalance { get; }

        [JsonInclude]
        public Dictionary<InstrumentJson, int> OpenPositions
        {
            get
            {
                return openPositions.ToDictionary(entry => entry.Key, entry => entry.Value);
            }
        }

        [JsonIgnore]
        private readonly Dictionary<InstrumentJson, int> openPositions;

        [JsonConstructor]
        public AccountJson(string login, string hashedPassword, decimal cashBalance, Dictionary<InstrumentJson, int> openPositions)
        {
            Login = login;
            HashedPassword = hashedPassword;
            CashBalance = cashBalance;
            this.openPositions = openPositions;
        }

        public AccountJson(Account account)
        {
            Login = account.Login;
            HashedPassword = account.HashedPassword;
            CashBalance = account.CashBalance;
            openPositions = account.OpenPositions.ToDictionary(entry => new InstrumentJson(entry.Key), entry => entry.Value);
        }

        public string ToJsonString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
