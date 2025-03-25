using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TradingPlatform.Model;
using TradingPlatform.Service.CashOperations;
using TradingPlatform.Service.Instruments;
using TradingPlatform.Service.Orders;
using TradingPlatform.Service.Prices;
using TradingPlatform.UI;

namespace TradingPlatform
{
    public partial class MainForm : Form, IPriceObserver
    {
        // Zalogowany użytkownik
        private readonly Account account;

        // Obiekty warstwy prezentacji
        private OpenPositionsTable openPositionsTable;
        private InstrumentListBox instrumentListBox;
        private PriceChart priceChart;

        private TextBoxComponent depositWithdrawalTextBox;
        private TextBoxComponent currentPriceTextBox;
        private TextBoxComponent availableFundsTextBox;
        private TextBoxComponent orderValueTextBox;

        // Obiekty warstwy serwisowej
        private readonly DepositHandler depositHandler;
        private readonly WithdrawalHandler withdrawalHandler;
        private readonly InstrumentProvider instrumentProvider;
        private readonly OrderHandler orderHandler;

        // Pola przechowujące bieżące dane rynkowe i wybory użytkownika
        private Instrument currentInstrument = null;
        private decimal currentPrice = 0;
        private int currentOrderVolume = 0;
        private Dictionary<string, Instrument> instruments = new Dictionary<string, Instrument>();
        private Dictionary<string, decimal> prices = new Dictionary<string, decimal>();

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
        }

        public void Initialize()
        {
            // Zanim wszystkie kontrolki zostaną zainicjalizowane (dzieje się to w osobnym wątku),
            // mogą wystąpić błędy - ponawiamy próbę ustawienia początkowych wartości co 100 milisekund
            while (true)
            {
                try
                {
                    CreateComponents();
                    SetInitialValues();
                    RefreshDisplayedValues();
                    
                    return;
                }
                catch
                {
                    Thread.Sleep(100);
                }
            }
        }

        public void HandlePricesPublished(Dictionary<string, decimal> prices)
        {
            this.prices = prices;
            string currentInstrumentName = currentInstrument.Name;

            if (prices.TryGetValue(currentInstrumentName, out decimal newPrice))
            {
                currentPrice = newPrice;
            }

            RefreshDisplayedValues();
            priceChart.AddPrice(currentPrice);
        }

        private void CreateComponents()
        {
            openPositionsTable = new OpenPositionsTable(dgvOpenPositions);
            priceChart = new PriceChart(crtPrices);
            depositWithdrawalTextBox = new TextBoxComponent(txtDepositWithdrawal);
            currentPriceTextBox = new TextBoxComponent(txtCurrentPrice);
            availableFundsTextBox = new TextBoxComponent(txtAvailableFunds);
            orderValueTextBox = new TextBoxComponent(txtOrderValue);
        }

        private void SetInitialValues()
        {
            SetInitialDepositWithdrawalText();
            SetInitialInstrumentList();
        }

        private void RefreshDisplayedValues()
        {
            RefreshAvailableFunds();
            RefreshOpenPositions();
            RefreshCurrentPriceText();
            RefreshOrderValue();
        }

        private void RefreshOpenPositions()
        {
            openPositionsTable.Refresh(account.OpenPositions, prices);
        }

        private void SetInitialDepositWithdrawalText()
        {
            depositWithdrawalTextBox.Text = "0.00";
        }

        private void SetInitialInstrumentList()
        {
            List<Instrument> instrumentList = instrumentProvider.GetAllInstruments();
            instruments = instrumentList.ToDictionary(instrument => instrument.Name);
            currentInstrument = instrumentList.First();
            instrumentListBox = new InstrumentListBox(lstInstruments, instrumentList);
        }

        private void RefreshCurrentPriceText()
        {
            currentPriceTextBox.Text = currentPrice.ToString();
        }

        private void RefreshAvailableFunds()
        {
            availableFundsTextBox.Text = account.CashBalance.ToString();
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
                // ignorowanie błędu parsowania - domyślna wartość (0) pozostaje aktywna
            }

            decimal orderValue = currentOrderVolume * currentPrice;

            orderValueTextBox.Text = orderValue.ToString();
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
            currentInstrument = instruments[instrumentListBox.SelectedItem];

            priceChart.Clear();
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
