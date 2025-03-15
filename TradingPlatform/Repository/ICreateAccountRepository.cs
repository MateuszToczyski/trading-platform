namespace TradingPlatform.Repository
{
    public interface ICreateAccountRepository
    {
        void CreateAccount(string login, string hashedPassword);
    }
}
