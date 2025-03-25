using System.Collections.Generic;
using System.Windows.Forms;
using TradingPlatform.Model;

namespace TradingPlatform.UI
{
    public class OpenPositionsTable : UIComponent
    {
        private readonly DataGridView dataGridView;

        public OpenPositionsTable(DataGridView dataGridView) : base(dataGridView)
        {
            this.dataGridView = dataGridView;

            Initialize();
        }

        public void Refresh(List<OpenPosition> openPositions, decimal currentPrice)
        {
            SafeInvoke(() =>
            {
                dataGridView.Rows.Clear();

                foreach (OpenPosition position in openPositions)
                {
                    AddRow(currentPrice, position);
                }

                dataGridView.AutoResizeColumns();
                dataGridView.AutoResizeRows();
            });
        }

        private void Initialize()
        {
            SafeInvoke(() =>
            {
                dataGridView.Columns.Clear();
                dataGridView.Columns.Add("Nazwa", "Nazwa");
                dataGridView.Columns.Add("Stan posiadania", "Stan posiadania");
                dataGridView.Columns.Add("Wartość bieżąca", "Wartość bieżąca");
            });
        }

        private void AddRow(decimal currentPrice, OpenPosition position)
        {
            Instrument instrument = position.Instrument;
            int volume = position.Volume;
            dataGridView.Rows.Add(instrument.GetFullName(), volume, volume * currentPrice);
        }
    }
}
