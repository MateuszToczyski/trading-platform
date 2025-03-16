using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TradingPlatform.Model;
using TradingPlatform.Service;

namespace TradingPlatform
{
    public partial class LoginForm : Form
    {
        private readonly AccountCreator accountCreator;
        private readonly LoginHandler loginHandler;
        private readonly CreateAccountMessageResolver createAccountMessageResolver = new CreateAccountMessageResolver();

        public LoginForm(AccountCreator accountCreator, LoginHandler loginHandler)
        {
            this.accountCreator = accountCreator;
            this.loginHandler = loginHandler;
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            Account account = loginHandler.Login(txtUsername.Text, txtPassword.Text);

            if (account == null)
            {
                MessageBox.Show("Niepoprawna nazwa użytkownika lub hasło");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            CreateAccountResult result = accountCreator.CreateAccount(txtUsername.Text, txtPassword.Text);
            string message = createAccountMessageResolver.GetMessage(result);
            MessageBox.Show(message);

            if (result == CreateAccountResult.Success)
            {
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
