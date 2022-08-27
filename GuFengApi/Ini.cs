using System;
using System.Runtime.InteropServices;
using System.Text;

namespace GuFengApi
{
    /// <summary>
    /// 读取 INI 文件
    /// </summary>
    internal class Ini
    {
        [DllImport("kernel32.dll")]
        protected static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32.dll")]
        protected static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        internal static void Write(string section, string key, string val, string path)
        {
            if (WritePrivateProfileString(section, key, val, path) != 0)
            {
                Exception ex = new Exception("Failed to write ini file!");
                throw ex;
            }
        }

        internal static string Read(string section, string key, string path)
        {
            StringBuilder builder = new StringBuilder(2048);
            GetPrivateProfileString(section, key, "!failed", builder, 2048, path);
            if (builder.ToString() == "!failed")
            {
                Exception ex = new Exception("Failed to read ini file!");
                throw ex;
            }
            return builder.ToString();
        }
    }
}
