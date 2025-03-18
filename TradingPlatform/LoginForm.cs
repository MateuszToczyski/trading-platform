using System;
using System.Windows.Forms;
using TradingPlatform.Model;
using TradingPlatform.Service.Accounts;

namespace TradingPlatform
{
    public partial class LoginForm : Form
    {
        public Account Account { get; private set; }

        private readonly AccountCreator accountCreator;
        private readonly LoginHandler loginHandler;

        public LoginForm(AccountCreator accountCreator, LoginHandler loginHandler)
        {
            this.accountCreator = accountCreator;
            this.loginHandler = loginHandler;
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            TryLogIn(txtUsername.Text, txtPassword.Text);
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            CreateAccountResult result = accountCreator.CreateAccount(username, password);
            ShowCreateAccountResultMessage(result);

            if (result == CreateAccountResult.Success)
            {
                TryLogIn(username, password);
            }
        }

        private void TryLogIn(string username, string password)
        {
            Account account = loginHandler.LogIn(username, password);
            
            if (account == null)
            {
                MessageBox.Show("Niepoprawna nazwa użytkownika lub hasło");
            }
            else
            {
                Account = account;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void ShowCreateAccountResultMessage(CreateAccountResult result)
        {
            switch (result)
            {
                case CreateAccountResult.Success:
                    MessageBox.Show("Konto utworzone pomyślnie");
                    break;
                case CreateAccountResult.Failure:
                    MessageBox.Show("Nie udało się utworzyć konta; spróbuj ponownie");
                    break;
                case CreateAccountResult.InvalidLogin:
                    MessageBox.Show("Nazwa użytkownika nie może być pusta i może zawierać tylko litery i cyfry");
                    break;
                case CreateAccountResult.InvalidPassword:
                    MessageBox.Show("Hasło zbyt krótkie - minimalna liczba znaków: " + PasswordValidator.PASSWORD_MIN_LENGTH);
                    break;
                case CreateAccountResult.AlreadyExists:
                    MessageBox.Show("Konto o podanej nazwie już istnieje");
                    break;
                default:
                    break;
            }
        }
    }
}
