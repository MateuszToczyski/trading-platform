using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TradingPlatform
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

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

            // TODO
            txtAvailableFunds.Text = "0";
        }
    }
}
