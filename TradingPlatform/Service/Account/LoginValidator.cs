using System.Text.RegularExpressions;

namespace TradingPlatform.Service
{
    public class LoginValidator
    {
        private readonly static string LOGIN_REGEX = "^[a-zA-Z0-9]+$";

        public bool IsLoginValid(string login)
        {
            return (login.Length > 0) && (Regex.IsMatch(login, LOGIN_REGEX));
        }
    }
}
