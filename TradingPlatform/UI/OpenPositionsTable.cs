using System.Collections.Generic;
using System.Windows.Forms;
using TradingPlatform.Model;

namespace TradingPlatform.UI
{
    public class OpenPositionsTable : UIComponent<DataGridView>
    {
        public OpenPositionsTable(DataGridView dataGridView) : base(dataGridView)
        {
            Initialize();
        }

        public void Refresh(List<OpenPosition> openPositions, Dictionary<string, decimal> prices)
        {
            SafeInvoke(() =>
            {
                control.Rows.Clear();

                foreach (OpenPosition position in openPositions)
                {
                    if (prices.TryGetValue(position.Instrument.Name, out decimal currentPrice))
                    {
                        AddRow(currentPrice, position);
                    }
                }

                control.AutoResizeColumns();
                control.AutoResizeRows();
            });
        }

        private void Initialize()
        {
            SafeInvoke(() =>
            {
                control.Columns.Clear();
                control.Columns.Add("Nazwa", "Nazwa");
                control.Columns.Add("Stan posiadania", "Stan posiadania");
                control.Columns.Add("Wartość bieżąca", "Wartość bieżąca");
            });
        }

        private void AddRow(decimal currentPrice, OpenPosition position)
        {
            Instrument instrument = position.Instrument;
            int volume = position.Volume;
            control.Rows.Add(instrument.GetFullName(), volume, volume * currentPrice);
        }
    }
}
