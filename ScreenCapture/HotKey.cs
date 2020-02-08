using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ScreenCapture
{
    public enum HotkeyModifiers
    {
        Name=0,
        Alt=1,
        Control=2,
        Shift=4,
        Win=8,
    }
    class HotKey
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, HotkeyModifiers modifers, Keys vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }
}
