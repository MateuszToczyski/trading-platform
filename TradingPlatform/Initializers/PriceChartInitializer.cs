using System.Windows.Forms.DataVisualization.Charting;

namespace TradingPlatform.Initializers
{
    class PriceChartInitializer : IComponentInitializer
    {
        private readonly Chart priceChart;

        public PriceChartInitializer(Chart priceChart)
        {
            this.priceChart = priceChart;
        }

        public void Initialize()
        {
            // TODO Load prices from database
            priceChart.Series.Add("Price");
            priceChart.Series["Price"].ChartType = SeriesChartType.Line;
            priceChart.Series["Price"].Points.AddXY(0, 1);
            priceChart.Series["Price"].Points.AddXY(1, 2);
            priceChart.Series["Price"].Points.AddXY(2, 3);
        }
    }
}
