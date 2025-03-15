using System.Windows.Forms;

namespace TradingPlatform.Initializers
{
    class InstrumentListInitializer : IComponentInitializer
    {
        private readonly ListBox instrumentList;

        public InstrumentListInitializer(ListBox instrumentList)
        {
            this.instrumentList = instrumentList;
        }

        public void Initialize()
        {
            // TODO: Load instruments from database
            instrumentList.Items.Add("EUR/USD");
            instrumentList.Items.Add("EUR/PLN");
            instrumentList.Items.Add("GOLD");
            instrumentList.Items.Add("SILVER");
        }
    }
}
