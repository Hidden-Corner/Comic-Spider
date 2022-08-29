using GuFengApi;
using System.IO;
using System;

namespace Shell
{
    /// <summary>
    /// 管理程序缓存
    /// </summary>
    internal class CacheManager
    {
        string cachePath;

        public CacheManager(string cachePath)
        {
            this.cachePath = cachePath;

            if (!Directory.Exists(cachePath))
            {
                Directory.CreateDirectory(cachePath);
            }
        }

        public string ReadCache(Uri uri)
        {
            string localPath = $"Cache/{uri.ToString().Split('/')[ToString().Length - 1]}";
            if (!File.Exists(localPath))
            {
                Client.Download(uri, localPath);
            }
            return localPath;
        }
    }
}
