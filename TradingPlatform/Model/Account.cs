namespace TradingPlatform.Model
{
    public class Account
    {
        private readonly string login;
        private readonly string hashedPassword;

        public Account(string login, string hashedPassword)
        {
            this.login = login;
            this.hashedPassword = hashedPassword;
        }
    }
}
