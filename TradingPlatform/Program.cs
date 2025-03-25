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
            // Podstawowa konfiguracja aplikacji Windows Forms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Tworzymy fabrykę, która dostarczy wszystkie potrzebne obiekty
            IFactory factory = new DemoFactory();

            AccountCreator accountCreator = factory.GetAccountCreator();
            LoginHandler loginHandler = factory.GetLoginHandler();

            // Uruchamiamy okno logowania / tworzenia konta
            using (var loginForm = new LoginForm(accountCreator, loginHandler))
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Udało się zalogować lub utworzyć konto - uruchamiamy główne okno aplikacji
                    Account account = loginForm.Account;
                    RunApplication(factory, account);
                }
                else
                {
                    // Logowanie lub tworzenie konta nieudane - kończymy działanie aplikacji
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

            // Application.Run jest to metoda blokująca, dlatego uruchamiamy ją w osobnym wątku
            Thread mainFormThread = new Thread(() => Application.Run(mainForm)) { IsBackground = false };
            mainFormThread.Start();

            pricePublisher.Start();
            mainForm.Initialize();

            // Dodajemy mainForm jako obserwatora publikacji cen, aby mógł reagować na ich zmiany
            pricePublisher.AddObserver(mainForm);
        }
    }
}
