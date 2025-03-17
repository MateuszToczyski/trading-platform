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

        [JsonConstructor]
        public AccountJson(string login, string hashedPassword, decimal cashBalance)
        {
            Login = login;
            HashedPassword = hashedPassword;
            CashBalance = cashBalance;
        }

        public AccountJson(Account account)
        {
            Login = account.Login;
            HashedPassword = account.HashedPassword;
            CashBalance = account.CashBalance;
        }

        public string ToJsonString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
