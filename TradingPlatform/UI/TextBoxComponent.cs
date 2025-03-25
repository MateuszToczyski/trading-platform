using System.Windows.Forms;

namespace TradingPlatform.UI
{
    class TextBoxComponent : UIComponent<TextBox>
    {
        public string Text
        {
            get
            {
                return SafeInvoke(() => control.Text);
            }
            set
            {
                SafeInvoke(() => control.Text = value);
            }
        }

        public TextBoxComponent(TextBox textBox) : base(textBox) { }
    }
}
