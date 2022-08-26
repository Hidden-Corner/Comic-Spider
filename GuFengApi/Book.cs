using System;
using System.Net;

namespace GuFengApi
{
    public class Book
    {
        string title;
        Uri cover;
        string updateTo; // 更新到哪个章节
        string time; // 最后更新时间
        Uri bookUri;

        public void DownloadTo(string path)
        {

        }

        public void DownloadSinglePageTo(int chapter, int page, string path)
        {

        }

        // 初始化相关，应给 Client 写入权限
        public string Title { get => title; internal set => title = value; }
        public Uri Cover { get => cover; internal set => cover = value; }
        public string UpdateTo { get => updateTo; internal set => updateTo = value; }
        public string Time { get => time; internal set => time = value; }
        internal Uri BookUri { get => bookUri; set => bookUri = value; }
    }
}
