using System.Text.RegularExpressions;

namespace TradingPlatform.Service.CashOperations
{
    public class AmountValidator
    {
        private readonly Regex amountRegex = new Regex("^\\d+(?:\\.\\d{1,2})?$");

        public bool IsAmountValid(string amount)
        {
            return amountRegex.IsMatch(amount);
        }
    }
}
