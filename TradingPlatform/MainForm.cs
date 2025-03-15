using System.Windows.Forms;

namespace TradingPlatform
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            new InstrumentListInitializer().Initialize(lstInstruments);

            // TODO Load prices from database
            crtPrices.Series.Add("Price");
            crtPrices.Series["Price"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            crtPrices.Series["Price"].Points.AddXY(0, 1);
            crtPrices.Series["Price"].Points.AddXY(1, 2);
            crtPrices.Series["Price"].Points.AddXY(2, 3);
        }
    }

    class InstrumentListInitializer
    {
        public void Initialize(ListBox lstInstruments)
        {
            // TODO: Load instruments from database
            lstInstruments.Items.Add("EUR/USD");
            lstInstruments.Items.Add("EUR/PLN");
            lstInstruments.Items.Add("GOLD");
            lstInstruments.Items.Add("SILVER");
        }
    }
}
