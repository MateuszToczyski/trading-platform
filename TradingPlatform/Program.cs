using System;
using System.Windows.Forms;
using TradingPlatform.Factory;
using TradingPlatform.Model;
using TradingPlatform.Service.Accounts;
using TradingPlatform.Service.CashOperations;

namespace TradingPlatform
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IFactory factory = new DemoFactory();

            AccountCreator accountCreator = factory.GetAccountCreator();
            LoginHandler loginHandler = factory.GetLoginHandler();
            DepositHandler depositHandler = factory.GetDepositHandler();
            WithdrawalHandler withdrawalHandler = factory.GetWithdrawalHandler();

            using (var loginForm = new LoginForm(accountCreator, loginHandler))
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Account account = loginForm.Account;
                    Application.Run(new MainForm(account, depositHandler, withdrawalHandler));
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
