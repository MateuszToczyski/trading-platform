using System;
using System.Threading;
using System.Windows.Forms;
using TradingPlatform.Factory;
using TradingPlatform.Model;
using TradingPlatform.Service.Accounts;
using TradingPlatform.Service.CashOperations;
using TradingPlatform.Service.Instruments;
using TradingPlatform.Service.Orders;
using TradingPlatform.Service.Prices;

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

            using (var loginForm = new LoginForm(accountCreator, loginHandler))
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Account account = loginForm.Account;
                    RunApplication(factory, account);
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private static void RunApplication(IFactory factory, Account account)
        {
            DepositHandler depositHandler = factory.GetDepositHandler();
            WithdrawalHandler withdrawalHandler = factory.GetWithdrawalHandler();
            InstrumentProvider instrumentProvider = factory.GetInstrumentProvider();
            OrderHandler orderHandler = factory.GetOrderHandler();
            PricePublisher pricePublisher = factory.GetPricePublisher();

            MainForm mainForm = new MainForm(account, depositHandler, withdrawalHandler, instrumentProvider, orderHandler);

            Thread mainFormThread = new Thread(() => Application.Run(mainForm)) { IsBackground = false };
            mainFormThread.Start();

            pricePublisher.Start();
            mainForm.Initialize();
            pricePublisher.AddObserver(mainForm);
        }
    }
}
