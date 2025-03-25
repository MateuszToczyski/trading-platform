using System.Windows.Forms;

namespace TradingPlatform.UI
{
    class TextBoxComponent : UIComponent
    {
        private readonly TextBox textBox;

        public string Text
        {
            get
            {
                return SafeInvoke(() => textBox.Text);
            }
            set
            {
                SafeInvoke(() => textBox.Text = value);
            }
        }

        public TextBoxComponent(TextBox textBox) : base(textBox)
        {
            this.textBox = textBox;
        }
    }
}
