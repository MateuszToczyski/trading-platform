using System.Collections.Generic;
using System.Windows.Forms;
using TradingPlatform.Model;

namespace TradingPlatform.UI
{
    class InstrumentListBox : UIComponent<ListBox>
    {
        public string SelectedItem
        {
            get
            {
                return SafeInvoke(() => control.SelectedItem.ToString());
            }
        }

        public InstrumentListBox(ListBox listBox, List<Instrument> instruments) : base(listBox)
        {
            Initialize(instruments);
        }

        private void Initialize(List<Instrument> instruments)
        {
            SafeInvoke(() =>
            {
                control.Items.Clear();

                foreach (Instrument instrument in instruments)
                {
                    control.Items.Add(instrument.Name);
                }

                control.SelectedIndex = 0;
            });
        }
    }
}
