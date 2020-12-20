using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Interop;
using static OverlayFullscreenPng.KeyHandler;

namespace OverlayFullscreenPng
{
    public partial class OverlayForm : Form
    {

        [DllImport("user32.dll", SetLastError = true)]
        private static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll")]
        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 SWP_NOZORDER = 0x0004;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        private const Int32 SW_RESTORE = 0x0009;
        private const Int32 WM_PAINT = 0x000f;
        private const Int32 SW_HIDE = 0x0000;

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        public const int GWL_EXSTYLE = -20;
        public const int WS_EX_LAYERED = 0x80000;
        public const int WS_EX_TRANSPARENT = 0x20;
        public const int WS_EX_TOPMOST = 0x00000008;
        public const int LWA_ALPHA = 0x2;
        public const int LWA_COLORKEY = 0x1;

        private Form _owner;
        private KeyHandler ghk;

        public OverlayForm(Form owner, Keys key, KeyModifier modifier, int opacity)
        {
            this._owner = owner;

            InitializeComponent();

            SetWindowLong(this.Handle, GWL_EXSTYLE, (IntPtr)(GetWindowLong(this.Handle, GWL_EXSTYLE) | WS_EX_LAYERED | WS_EX_TRANSPARENT));
            SetLayeredWindowAttributes(this.Handle, 0, (byte)((opacity / 100.0) * 255), LWA_ALPHA);

            ghk = new KeyHandler(key, modifier, this);
            ghk.Register();

            this.BackColor = Color.WhiteSmoke;
            this.TransparencyKey = this.BackColor;

            this.Opacity = (opacity / 100.0);
        }


        private const int WM_MOUSEACTIVATE = 0x0021;
        private const int MA_NOACTIVATEANDEAT = 0x0004;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == KeyHandler.WM_HOTKEY_MSG_ID)
                HandleHotkey();

            if (m.Msg == WM_MOUSEACTIVATE)
            {
                m.Result = (IntPtr)MA_NOACTIVATEANDEAT;
                return;
            }
            base.WndProc(ref m);
        }

        private void HandleHotkey()
        {
            this.Close();
            _owner.Show();
        }
    }

    public class WindowFinder
    {
        // For Windows Mobile, replace user32.dll with coredll.dll
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public static IntPtr FindWindow(string caption)
        {
            return FindWindow(null, caption);
        }

    }

    public class KeyHandler
    {
        public enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        public const int WM_HOTKEY_MSG_ID = 0x0312;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private int key;
        private int modifier;
        private IntPtr hWnd;
        private int id;

        public KeyHandler(Keys key, KeyModifier modifier, Form form)
        {
            this.key = (int)key;
            this.modifier = (int)modifier;
            this.hWnd = form.Handle;
            id = this.GetHashCode();
        }

        public override int GetHashCode()
        {
            return key ^ hWnd.ToInt32();
        }

        public bool Register()
        {
            return RegisterHotKey(hWnd, id, modifier, key);
        }

        public bool Unregiser()
        {
            return UnregisterHotKey(hWnd, id);
        }
    }
    [Flags]
    public enum WindowStyles : int
    {
        WS_BORDER = 0x800000,
        WS_CAPTION = 0xc00000,
        WS_CHILD = 0x40000000,
        WS_CLIPCHILDREN = 0x2000000,
        WS_CLIPSIBLINGS = 0x4000000,
        WS_DISABLED = 0x8000000,
        WS_DLGFRAME = 0x400000,
        WS_GROUP = 0x20000,
        WS_HSCROLL = 0x100000,
        WS_MAXIMIZE = 0x1000000,
        WS_MAXIMIZEBOX = 0x10000,
        WS_MINIMIZE = 0x20000000,
        WS_MINIMIZEBOX = 0x20000,
        WS_OVERLAPPED = 0x0,
        WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_SIZEFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,
        WS_POPUP = 0x8000000,
        WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU,
        WS_SIZEFRAME = 0x40000,
        WS_SYSMENU = 0x80000,
        WS_TABSTOP = 0x10000,
        WS_VISIBLE = 0x10000000,
        WS_VSCROLL = 0x200000
    }
    internal class WindowsExtendedStyles
    {

        public const int WS_EX_DLGMODALFRAME = 0x00000001;

        public const int WS_EX_NOPARENTNOTIFY = 0x00000004;

        public const int WS_EX_TOPMOST = 0x00000008;

        public const int WS_EX_ACCEPTFILES = 0x00000010;

        public const int WS_EX_TRANSPARENT = 0x00000020;

        public const int WS_EX_MDICHILD = 0x00000040;

        public const int WS_EX_TOOLWINDOW = 0x00000080;

        public const int WS_EX_WINDOWEDGE = 0x00000100;

        public const int WS_EX_CLIENTEDGE = 0x00000200;

        public const int WS_EX_CONTEXTHELP = 0x00000400;

        public const int WS_EX_RIGHT = 0x00001000;

        public const int WS_EX_LEFT = 0x00000000;

        public const int WS_EX_RTLREADING = 0x00002000;

        public const int WS_EX_LTRREADING = 0x00000000;

        public const int WS_EX_LEFTSCROLLBAR = 0x00004000;

        public const int WS_EX_RIGHTSCROLLBAR = 0x00000000;

        public const int WS_EX_CONTROLPARENT = 0x00010000;

        public const int WS_EX_STATICEDGE = 0x00020000;

        public const int WS_EX_APPWINDOW = 0x00040000;

        public const int WS_EX_OVERLAPPEDWINDOW = WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE;

        public const int WS_EX_PALETTEWINDOW = WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST;

        public const int WS_EX_LAYERED = 0x00080000;

        public const int WS_EX_NOINHERITLAYOUT = 0x00100000; // Disable inheritence of mirroring by children

        public const int WS_EX_LAYOUTRTL = 0x00400000; // Right to left mirroring

        public const int WS_EX_COMPOSITED = 0x02000000;

        public const int WS_EX_NOACTIVATE = 0x08000000;

    }
}
