using System;
using System.Windows.Forms;

namespace TradingPlatform.UI
{
    public abstract class UIComponent
    {
        private readonly Control control;

        public UIComponent(Control control)
        {
            this.control = control;
        }

        // Modyfikacja kontrolki może być wykonywana tylko w dedykowanym wątku
        protected void SafeInvoke(MethodInvoker action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }

        // Przeładowanie SafeInvoke dla funkcji zwracających wartość
        protected T SafeInvoke<T>(Func<T> func)
        {
            if (control.InvokeRequired)
            {
                return (T)control.Invoke(func);
            }
            else
            {
                return func();
            }
        }
    }
}
