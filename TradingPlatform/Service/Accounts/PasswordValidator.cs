namespace TradingPlatform.Service.Accounts
{
    public class PasswordValidator
    {
        public readonly static int PASSWORD_MIN_LENGTH = 8;

        public bool IsPasswordValid(string password)
        {
            if (password.Length < PASSWORD_MIN_LENGTH)
            {
                return false;
            }
            return true;
        }
    }
}
