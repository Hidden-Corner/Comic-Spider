using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shell
{
    internal static class Program
    {
        internal static CacheManager Cache = new CacheManager("Cache");
        internal static DownloadQueue DownloadQueue = new DownloadQueue();
        internal static MainForm MainForm;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new MainForm();
            Application.Run(MainForm);
        }
    }
}
