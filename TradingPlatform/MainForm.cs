using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TradingPlatform.Model;
using TradingPlatform.Service.CashOperations;

namespace TradingPlatform
{
    public partial class MainForm : Form
    {
        private readonly Account account;
        private readonly DepositHandler depositHandler;
        private readonly WithdrawalHandler withdrawalHandler;

        public MainForm(Account account, DepositHandler depositHandler, WithdrawalHandler withdrawalHandler)
        {
            this.account = account;
            this.depositHandler = depositHandler;
            this.withdrawalHandler = withdrawalHandler;

            InitializeComponent();
            SetDefaultValues();
            RefreshComponent();

            // TODO
            lstInstruments.Items.Add("KGH");
            lstInstruments.Items.Add("CDR");
            lstInstruments.Items.Add("LTS");

            // TODO
            crtPrices.Series.Add("Kurs");
            crtPrices.Series["Kurs"].ChartType = SeriesChartType.Line;
            crtPrices.Series["Kurs"].Points.AddXY(0, 1);
            crtPrices.Series["Kurs"].Points.AddXY(1, 2);
            crtPrices.Series["Kurs"].Points.AddXY(2, 3);

            // TODO
            dgvOpenPositions.Columns.Add("Nazwa", "Nazwa");
            dgvOpenPositions.Columns.Add("Stan posiadania", "Stan posiadania");
            dgvOpenPositions.Columns.Add("Cena otwarcia", "Cena otwarcia");
            dgvOpenPositions.Columns.Add("Cena bieżąca", "Cena bieżąca");
            dgvOpenPositions.Columns.Add("Wynik", "Wynik");

            // TODO
            dgvOpenPositions.Rows.Add("KGH", 1000, "BUY", 1.1, 1.2, 100);
            dgvOpenPositions.Rows.Add("CDR", 1000, "SELL", 4.5, 4.4, -100);
            this.withdrawalHandler = withdrawalHandler;
        }

        private void SetDefaultValues()
        {
            txtDepositWithdrawal.Text = "0.00";
        }

        private void RefreshComponent()
        {
            txtAvailableFunds.Text = account.CashBalance.ToString();
        }

        private void btnDeposit_Click(object sender, System.EventArgs e)
        {
            string amount = txtDepositWithdrawal.Text;
            DepositResult result = depositHandler.Deposit(account, amount);

            if (result == DepositResult.InvalidAmount)
            {
                MessageBox.Show("Wprowadź poprawną dodatnią kwotę (maks. 2 miejsca dziesiętne po kropce)");
            }

            RefreshComponent();
        }

        private void btnWithdrawal_Click(object sender, System.EventArgs e)
        {
            string amount = txtDepositWithdrawal.Text;
            WithdrawalResult result = withdrawalHandler.Withdraw(account, amount);

            if (result == WithdrawalResult.InvalidAmount)
            {
                MessageBox.Show("Wprowadź poprawną dodatnią kwotę (maks. 2 miejsca dziesiętne po kropce)");
            }
            else if (result == WithdrawalResult.InsufficientFunds)
            {
                MessageBox.Show("Brak wystarczających środków na koncie");
            }

            RefreshComponent();
        }
    }
}
