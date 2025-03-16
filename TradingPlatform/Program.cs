using System;
using System.Windows.Forms;
using TradingPlatform.Factory;
using TradingPlatform.Service;

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
                    Application.Run(new MainForm());
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
