using System;
using System.Collections.Generic;
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
        private readonly CreateAccountMessageResolver createAccountMessageResolver = new CreateAccountMessageResolver();

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
            string message = createAccountMessageResolver.GetMessage(result);
            MessageBox.Show(message);

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
    }

    class CreateAccountMessageResolver
    {
        private readonly Dictionary<CreateAccountResult, string> createAccountResultMessages = new Dictionary<CreateAccountResult, string>
        {
            { CreateAccountResult.Success, "Konto utworzone pomyślnie" },
            { CreateAccountResult.Failure, "Nie udało się utworzyć konta; spróbuj ponownie" },
            { CreateAccountResult.InvalidLogin, "Nazwa użytkownika nie może być pusta i może zawierać tylko litery i cyfry" },
            { CreateAccountResult.InvalidPassword, "Hasło zbyt krótkie - minimalna liczba znaków: " + PasswordValidator.PASSWORD_MIN_LENGTH },
            { CreateAccountResult.AlreadyExists, "Konto o podanej nazwie już istnieje" }
        };

        public string GetMessage(CreateAccountResult result)
        {
            return createAccountResultMessages[result];
        }
    }
}
