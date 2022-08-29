using System.Runtime.InteropServices;
using System;
using System.Windows.Forms;
using GuFengApi;
using Shell.Subforms;

namespace Shell
{
    public partial class MainForm : Form
    {
        internal Home fHome = new Home();
        internal Download fDownload = new Download();
        internal History fHistory = new History();
        internal Settings fSettings = new Settings();
        internal About fAbout = new About();

        Client api;

        public MainForm()
        {
            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
            try
            {
                api = new Client();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[warning]{DateTime.Now}:Failed to read Settings.ini. Use \"https://www.123gf.com/\" as the default address of website.");
                api = new Client("https://www.123gf.com/");
            }
            InitializeComponent();
            SwitchSubform(fHome);
        }

        protected void SwitchSubform(Form sf)
        {
            foreach(var item in this.panelSubform.Controls)
            {
                if (item is Form)
                {
                    (item as Form).Hide();
                }
            }
            sf.TopLevel = false;
            sf.Parent = this.panelSubform;
            sf.Dock = DockStyle.Fill;
            sf.Show();
        }

        #region 右上角控件实现
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
        #endregion

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
                Console.WriteLine($"[info]{DateTime.Now}: Search title: {searchBar.Text}");
                SwitchSubform(fHome);
                fHome.RefreshList(searchBar.Text, api);
            }
        }

        #region 侧边栏点击事件
        protected void MoveSide(int location)
        {
            panelSide.Location = new System.Drawing.Point(0, 10 + location);
        }

        private void btnMainPage_Click(object sender, EventArgs e)
        {
            MoveSide(btnMainPage.Location.Y);
            SwitchSubform(fHome);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            MoveSide(btnDownload.Location.Y);
            SwitchSubform(fDownload);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            MoveSide(btnHistory.Location.Y);
            SwitchSubform(fHistory);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            MoveSide(btnSettings.Location.Y);
            SwitchSubform(fSettings);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MoveSide(btnAbout.Location.Y);
            SwitchSubform(fAbout);
        }
        #endregion
    }
}
