using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using TradingPlatform.Json;

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
        public List<OpenPosition> OpenPositions
        {
            get
            {
                return openPositions.ToList();
            }
        }

        [JsonIgnore]
        private readonly List<OpenPosition> openPositions;

        [JsonConstructor]
        public AccountJson(string login, string hashedPassword, decimal cashBalance, List<OpenPosition> openPositions)
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
            openPositions = account.OpenPositions;
        }

        public string ToJsonString()
        {
            return JsonSerializer.Serialize(this, JsonOptions.WithEnumConversion);
        }
    }
}
