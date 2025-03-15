using System.Windows.Forms;
using TradingPlatform.Initializers;

namespace TradingPlatform
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            new InstrumentListInitializer(lstInstruments).Initialize();
            new PriceChartInitializer(crtPrices).Initialize();
        }
    }
}
