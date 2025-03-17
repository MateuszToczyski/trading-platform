using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TradingPlatform.Model;
using TradingPlatform.Service.CashOperations;
using TradingPlatform.Service.Instruments;
using TradingPlatform.Service.Prices;

namespace TradingPlatform
{
    public partial class MainForm : Form, IPriceObserver
    {
        private readonly static string CHART_SERIES_NAME = "Kurs";

        private readonly Account account;
        private readonly DepositHandler depositHandler;
        private readonly WithdrawalHandler withdrawalHandler;
        private readonly InstrumentProvider instrumentProvider;

        private string currentInstrument;

        public MainForm(
            Account account,
            DepositHandler depositHandler,
            WithdrawalHandler withdrawalHandler,
            InstrumentProvider instrumentProvider)
        {
            this.account = account;
            this.depositHandler = depositHandler;
            this.withdrawalHandler = withdrawalHandler;
            this.instrumentProvider = instrumentProvider;

            InitializeComponent();
            SetInitialValues();
            RefreshComponent();

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

        public void HandlePricesPublished(Dictionary<string, decimal> prices)
        {
            decimal currentInstrumentPrice = prices[currentInstrument];

            if (currentInstrumentPrice != 0)
            {
                // Ceny publikowane są w osobnym wątku - komponenty interfejsu graficznego muszą być modyfikowane w dedykowanym wątku
                crtPrices.Invoke((MethodInvoker)delegate
                {
                    crtPrices.Series[CHART_SERIES_NAME].Points.AddY(currentInstrumentPrice);
                    crtPrices.ChartAreas[0].AxisY.Minimum = ((double)currentInstrumentPrice) * 0.95;
                    crtPrices.ChartAreas[0].AxisY.Maximum = ((double)currentInstrumentPrice) * 1.05;
                });
            }
        }

        private void SetInitialValues()
        {
            SetInitialDepositWithdrawalText();
            SetInitialInstrumentList();
            SetUpPriceChart();
        }

        private void RefreshComponent()
        {
            RefreshAvailableFunds();
        }

        private void SetInitialDepositWithdrawalText()
        {
            txtDepositWithdrawal.Text = "0.00";
        }

        private void SetInitialInstrumentList()
        {
            lstInstruments.Items.Clear();

            foreach (Instrument instrument in instrumentProvider.GetAllInstruments())
            {
                lstInstruments.Items.Add(instrument.Name);
            }

            lstInstruments.SelectedIndex = 0;
            currentInstrument = lstInstruments.SelectedItem.ToString();
        }

        private void SetUpPriceChart()
        {
            crtPrices.Series.Add(CHART_SERIES_NAME);
            crtPrices.Series[CHART_SERIES_NAME].ChartType = SeriesChartType.Line;
        }

        private void RefreshAvailableFunds()
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
