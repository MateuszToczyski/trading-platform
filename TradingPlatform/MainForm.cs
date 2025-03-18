using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TradingPlatform.Model;
using TradingPlatform.Service.CashOperations;
using TradingPlatform.Service.Instruments;
using TradingPlatform.Service.Orders;
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
        private readonly OrderHandler orderHandler;

        private Instrument currentInstrument = null;
        private decimal currentPrice = 0;
        private int currentOrderVolume = 0;
        private Dictionary<string, Instrument> instruments = new Dictionary<string, Instrument>();

        public bool SetUpComplete { get; private set; } = false;

        public MainForm(
            Account account,
            DepositHandler depositHandler,
            WithdrawalHandler withdrawalHandler,
            InstrumentProvider instrumentProvider,
            OrderHandler orderHandler)
        {
            this.account = account;
            this.depositHandler = depositHandler;
            this.withdrawalHandler = withdrawalHandler;
            this.instrumentProvider = instrumentProvider;
            this.orderHandler = orderHandler;

            InitializeComponent();
            SetUpComplete = true;
        }

        public void Initialize()
        {
            SetInitialValues();
            RefreshDisplayedValues();
        }

        public void HandlePricesPublished(Dictionary<string, decimal> prices)
        {
            string currentInstrumentName = currentInstrument.Name;

            if (prices.ContainsKey(currentInstrumentName) == false)
            {
                return;
            }

            currentPrice = prices[currentInstrumentName];

            RefreshDisplayedValues();
            AddCurrentPriceToChart();
        }

        private void SetInitialValues()
        {
            SetUpOpenPositionsTable();
            SetInitialDepositWithdrawalText();
            SetInitialInstrumentList();
            SetUpPriceChart();
        }

        private void RefreshDisplayedValues()
        {
            RefreshAvailableFunds();
            RefreshOpenPositions();
            RefreshCurrentPriceText();
            RefreshOrderValue();
        }

        private void SetUpOpenPositionsTable()
        {
            dgvOpenPositions.Columns.Add("Nazwa", "Nazwa");
            dgvOpenPositions.Columns.Add("Stan posiadania", "Stan posiadania");
            dgvOpenPositions.Columns.Add("Wartość bieżąca", "Wartość bieżąca");
        }

        private void RefreshOpenPositions()
        {
            dgvOpenPositions.Rows.Clear();
            
            foreach (KeyValuePair<Instrument, int> entry in account.OpenPositions.ToList())
            {
                Instrument instrument = entry.Key;
                int volume = entry.Value;
                dgvOpenPositions.Rows.Add(instrument.GetFullName(), volume, volume * currentPrice);
            }
        }

        private void SetInitialDepositWithdrawalText()
        {
            txtDepositWithdrawal.Text = "0.00";
        }

        private void SetInitialInstrumentList()
        {
            List<Instrument> instruments = instrumentProvider.GetAllInstruments();
            this.instruments = instruments.ToDictionary(instrument => instrument.Name);

            lstInstruments.Items.Clear();

            foreach (Instrument instrument in instruments)
            {
                lstInstruments.Items.Add(instrument.Name);
            }

            lstInstruments.SelectedIndex = 0;
            currentInstrument = this.instruments[lstInstruments.SelectedItem.ToString()];
        }

        private void SetUpPriceChart()
        {
            crtPrices.Series.Add(CHART_SERIES_NAME);
            crtPrices.Series[CHART_SERIES_NAME].ChartType = SeriesChartType.Line;
        }

        private void AddCurrentPriceToChart()
        {
            crtPrices.Invoke((MethodInvoker)delegate
            {
                crtPrices.Series[CHART_SERIES_NAME].Points.AddY(currentPrice);
                crtPrices.ChartAreas[0].AxisY.Minimum = Math.Round(((double)currentPrice) * 0.95, 0);
                crtPrices.ChartAreas[0].AxisY.Maximum = Math.Round(((double)currentPrice) * 1.05, 0);
            });
        }

        private void RefreshCurrentPriceText()
        {
            txtCurrentPrice.Invoke((MethodInvoker)delegate
            {
                txtCurrentPrice.Text = currentPrice.ToString();
            });
        }

        private void RefreshAvailableFunds()
        {
            txtAvailableFunds.Text = account.CashBalance.ToString();
        }

        private void RefreshOrderValue()
        {
            currentOrderVolume = 0;
            
            try
            {
                currentOrderVolume = int.Parse(txtOrderAmount.Text);
            }
            catch
            {
                // ignore
            }

            decimal orderValue = currentOrderVolume * currentPrice;

            txtOrderValue.Invoke((MethodInvoker)delegate
            {
                txtOrderValue.Text = orderValue.ToString();
            });
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            string amount = txtDepositWithdrawal.Text;
            DepositResult result = depositHandler.Deposit(account, amount);

            if (result == DepositResult.InvalidAmount)
            {
                MessageBox.Show("Wprowadź poprawną dodatnią kwotę (maks. 2 miejsca dziesiętne po kropce)");
            }

            RefreshDisplayedValues();
        }

        private void btnWithdrawal_Click(object sender, EventArgs e)
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

            RefreshDisplayedValues();
        }

        private void lstInstruments_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentInstrument = instruments[lstInstruments.SelectedItem.ToString()];

            if (crtPrices.Series.Count > 0)
            {
                crtPrices.Series[CHART_SERIES_NAME].Points.Clear();
            }
        }

        private void txtOrderAmount_TextChanged(object sender, EventArgs e)
        {
            RefreshDisplayedValues();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            BuyOrderResult result = orderHandler.PlaceBuyOrder(account, currentInstrument, currentOrderVolume, currentPrice);
            RefreshDisplayedValues();
            ShowBuyOrderResultMessage(result);
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            SellOrderResult result = orderHandler.PlaceSellOrder(account, currentInstrument, currentOrderVolume, currentPrice);
            RefreshDisplayedValues();
            ShowSellOrderResultMessage(result);
        }

        private void ShowBuyOrderResultMessage(BuyOrderResult result)
        {
            switch (result)
            {
                case BuyOrderResult.InvalidVolume:
                    MessageBox.Show("Liczba sztuk musi być dodatnią liczbą całkowitą");
                    break;
                case BuyOrderResult.InvalidPrice:
                    MessageBox.Show("Wprowadź poprawną dodatnią cenę instrumentu (maks. 2 miejsca dziesiętne po kropce)");
                    break;
                case BuyOrderResult.InsufficientFunds:
                    MessageBox.Show("Brak wystarczających środków na koncie");
                    break;
                case BuyOrderResult.Success:
                    MessageBox.Show("Zlecenie kupna zrealizowane pomyślnie");
                    break;
                default:
                    break;
            }
        }

        private void ShowSellOrderResultMessage(SellOrderResult result)
        {
            switch (result)
            {
                case SellOrderResult.InvalidVolume:
                    MessageBox.Show("Liczba sztuk musi być dodatnią liczbą całkowitą");
                    break;
                case SellOrderResult.InvalidPrice:
                    MessageBox.Show("Wprowadź poprawną dodatnią cenę instrumentu (maks. 2 miejsca dziesiętne po kropce)");
                    break;
                case SellOrderResult.InsufficientPosition:
                    MessageBox.Show("Brak wystarczającej liczby sztuk instrumentu w posiadaniu");
                    break;
                case SellOrderResult.Success:
                    MessageBox.Show("Zlecenie sprzedaży zrealizowane pomyślnie");
                    break;
                default:
                    break;
            }
        }
    }
}
