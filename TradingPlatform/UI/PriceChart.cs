using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace TradingPlatform.UI
{
    class PriceChart : UIComponent<Chart>
    {
        private readonly static string CHART_SERIES_NAME = "PRICE";
        private readonly static double Y_AXIS_PADDING = 0.05;

        public PriceChart(Chart chart) : base(chart)
        {
            Initialize();
        }

        public void AddPrice(decimal price)
        {
            SafeInvoke(() =>
            {
                control.Series[CHART_SERIES_NAME].Points.AddY(price);
                RescaleYAxis((double)price);
            });
        }

        public void Clear()
        {
            SafeInvoke(() =>
            {
                if (control.Series.Count > 0)
                {
                    control.Series[CHART_SERIES_NAME].Points.Clear();
                }
            });
        }

        private void Initialize()
        {
            SafeInvoke(() =>
            {
                control.Series.Clear();
                control.Series.Add(CHART_SERIES_NAME);
                control.Series[CHART_SERIES_NAME].ChartType = SeriesChartType.Line;
            });
        }

        private void RescaleYAxis(double currentPrice)
        {
            control.ChartAreas[0].AxisY.Minimum = Math.Round((currentPrice) * Y_AXIS_PADDING, 0);
            control.ChartAreas[0].AxisY.Maximum = Math.Round((currentPrice) * Y_AXIS_PADDING, 0);
        }
    }
}
