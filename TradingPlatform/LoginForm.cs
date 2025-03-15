using System;
using System.Windows.Forms;

namespace TradingPlatform
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            // TODO login logic
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
