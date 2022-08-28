using System.Runtime.InteropServices;
using System;
using System.Windows.Forms;

namespace Shell
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
            InitializeComponent();
        }

        private void ClickExitBtn(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void ClickMaximizeBtn(object sender, System.EventArgs e)
        {
            this.WindowState = (this.WindowState != FormWindowState.Maximized) ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        private void ClickMinimizeBtn(object sender, System.EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #region 拖动窗口相关
        [DllImport("user32.dll")]//拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private void DragWindow(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        #endregion

        private void StartSearching(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Console.WriteLine($"Start Searching! Book name: {searchBar.Text}");
            }
        }
    }
}
