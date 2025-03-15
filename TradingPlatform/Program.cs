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

            AccountCreator accountCreator = new AccountCreatorFactory().Create();

            using (var loginForm = new LoginForm(accountCreator))
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
