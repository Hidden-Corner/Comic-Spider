using System;
using System.IO;
using System.Windows.Forms;

namespace Shell
{
    internal static class Program
    {
        internal static CacheManager Cache = new CacheManager("Cache");
        internal static MainForm MainForm;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine($"[info]({DateTime.Now}): Start from \"{Directory.GetCurrentDirectory()}\"");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new MainForm();
            Control.CheckForIllegalCrossThreadCalls = false;
            Application.Run(MainForm);
        }
    }
}
