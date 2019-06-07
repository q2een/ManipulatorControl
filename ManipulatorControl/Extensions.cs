using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ManipulatorControl
{
    internal static class Extensions
    {
        internal static void Visible(this ToolStripMenuItem menuItem, bool isVisible)
        {
            menuItem.Enabled = isVisible;
            menuItem.Visible = isVisible;
        }

        internal static void InvokeEx(this Control control, Action action)
        {
            try
            {
                if (control.InvokeRequired)
                    control.Invoke(action);
                else
                    action();
            }
            catch(ObjectDisposedException)
            {

            }
        }
    }
}

