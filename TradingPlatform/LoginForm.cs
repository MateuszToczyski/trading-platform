using System;
using System.Windows.Forms;
using TradingPlatform.Service;

namespace TradingPlatform
{
    public partial class LoginForm : Form
    {
        private readonly AccountCreator accountCreator;

        public LoginForm(AccountCreator accountCreator)
        {
            this.accountCreator = accountCreator;
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            // TODO login logic
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            CreateAccountResult result = accountCreator.CreateAccount(txtUsername.Text, txtPassword.Text);
            
            switch (result)
            {
                case CreateAccountResult.Success:
                    this.DialogResult = DialogResult.OK;
                    this.Close();
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
            }
        }
    }
}
