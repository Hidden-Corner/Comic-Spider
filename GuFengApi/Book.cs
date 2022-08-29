// Copyright (C) 2022 Hidden Corner
// 对漫画的封装类

using System;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using Microsoft.WindowsAPICodePack.Shell;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Xml.Linq;

namespace GuFengApi
{
    public class Book : IDisposable
    {
        string title;
        Uri cover;
        string updateTo; // 更新到哪个章节
        string time; // 最后更新时间
        Uri bookUri;

        public class Chapter : IDisposable
        {
            string name;
            Uri uri;
            Uri[] pages;

            public string Name { get => name; internal set => name = value; }
            public Uri[] Pages { get => pages; internal set => pages = value; }
            public Uri Uri { get => uri; internal set => uri = value; }
            public int Count => Pages.Length;

            #region IDisposable 派生实现
            bool disposed = false;

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            ~Chapter()
            {
                Dispose(false);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (disposed)
                {
                    return;
                }
                //清理托管资源
                if (disposing)
                {
                    if (name != null)
                        name = null;
                    if (uri != null)
                        uri = null;
                    if (pages != null)
                    {
                        for (int i = 0; i < pages.Length; i++)
                            pages[i] = null;
                        pages = null;
                    }
                }
                //告诉自己已经被释放
                disposed = true;
            }
            #endregion
        }

        Chapter[] chapters;

        #region 内部方法
        protected Chapter[] InitChapters()
        {
            HtmlDocument doc = Client.GetDocument(bookUri);
            HtmlNodeCollection chapterNodes = doc.DocumentNode.SelectNodes("//div[@class='chapter-body clearfix']/ul/li/a");
            Chapter[] chapters = new Chapter[chapterNodes.Count];

            for (int i = 0; i < chapterNodes.Count; ++i)
            {
                chapters[i] = new Chapter();
                chapters[i].Name = chapterNodes[i].SelectSingleNode("./span").InnerText;
                chapters[i].Uri = new Uri($"https://{bookUri.Host}{chapterNodes[i].Attributes["href"].Value.ToString()}");
            }

            return chapters;
        }
        internal static Uri[] InitPages(Uri uri)
        {
            string script = Client.GetDocument(uri).DocumentNode.SelectSingleNode("/html/body/script").InnerText;

            // 剩下的代码基本照搬 non-gui 分支
            // 原理就是通过正则表达式匹配 HTML 下的 Script 里写好的图片编号，计算资源站里图片源地址
            MatchCollection matches = Regex.Matches(Regex.Match(script, @"var chapterImages = \[.*\]").Value, @"[^\""]+\.jpg");
            Uri[] pages = new Uri[matches.Count];
            string chapterPath = Regex.Match(script, @"images/comic/[0-9]+/[0-9]+/").Value;
            for (int i = 0; i < matches.Count; i++)
            {
                pages[i] = new Uri("https://res.xiaoqinre.com/" + chapterPath + matches[i].Value);
            }
            return pages;
        }
        internal static string GetDownloadPath()
        {
            string path;
            try
            {
                path = Ini.Read("Settings", "DownloadPath", "Settings.ini");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[warning]{DateTime.Now}: Failed to read Settings.ini. Use \"{KnownFolders.Downloads.Path + "\\ComicSpider"}\" as default download path.");
                return KnownFolders.Downloads.Path + "\\ComicSpider";
            }
            if (path == "?" || !Directory.Exists(path))
            {
                Ini.Write("Settings", "DownloadPath", KnownFolders.Downloads.Path, "Settings.ini");
                return KnownFolders.Downloads.Path + "\\ComicSpider";
            }
            return path;
        }
        #endregion

        #region 初始化相关
        public string Title { get => title; internal set => title = value; }
        public Uri Cover { get => cover; internal set => cover = value; }
        public string UpdateTo { get => updateTo; internal set => updateTo = value; }
        public string Time { get => time; internal set => time = value; }
        public Uri BookUri { get => bookUri; internal set => bookUri = value; }
        public Chapter[] Chapters { get { if (chapters == null) chapters = InitChapters(); return chapters; } internal set => chapters = value; }
        #endregion

        #region IDisposable 派生实现
        bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Book()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            //清理托管资源
            if (disposing)
            {
                if (title != null)
                    title = null;
                if (cover != null)
                    cover = null;
                if (updateTo != null)
                    updateTo = null;
                if (bookUri != null)
                    bookUri = null;
                if (chapters != null)
                {
                    foreach(var chapter in chapters)
                        chapter.Dispose();
                    chapters = null;
                }
            }
            //告诉自己已经被释放
            disposed = true;
        }
        #endregion
    }
}
