﻿// Copyright (C) 2022 Hidden Corner
// 对漫画的封装类

using System;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using Microsoft.WindowsAPICodePack.Shell;
using System.IO;
using System.Runtime.InteropServices;

namespace GuFengApi
{
    public class Book
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

        /// <summary>
        /// 把整本书下载到指定目录
        /// </summary>
        /// <param name="path">指定目录</param>
        public void Download()
        {
            if (chapters == null)
                chapters = InitChapters();
            // 直接调用现成的函数
            for (int i = 0; i < chapters.Length; ++i)
            {
                DownloadSingleChapter(i);
            }
        }

        /// <summary>
        /// 仅下载指定章节到目录
        /// </summary>
        /// <param name="rank">章节序号</param>
        /// <param name="path">目录</param>
        public void DownloadSingleChapter(int rank)
        {
            if (chapters == null)
                chapters = InitChapters();
            if (chapters[rank].Pages == null)
                chapters[rank].Pages = InitPages(chapters[rank].Uri);

            using (var target = chapters[rank]) {
                string path = GetDownloadPath() + "/ComicSpider";

                #region 检查文件下载目录是否存在
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (!Directory.Exists($"{path}/{title}"))
                    Directory.CreateDirectory(path + $"/{title}");
                if (!Directory.Exists($"{path}/{title}/{target.Name}"))
                    Directory.CreateDirectory($"{path}/{title}/{target.Name}");
                #endregion

                path = $"{path}/{title}/{target.Name}";
                for (int i = 0; i < target.Pages.Length; ++i)
                {
                    // 逐一下载图片
                    Client.Download(target.Pages[i], $"{path}/{i + 1}.jpg");
                }
            }
        }

        protected Chapter[] InitChapters()
        {
            HtmlDocument doc = Client.GetDocument(bookUri);
            HtmlNodeCollection chapterNodes = doc.DocumentNode.SelectNodes("//div[@class='chapter-body clearfix']/ul[@id='chapter-list-1']/li/a");
            Chapter[] chapters = new Chapter[chapterNodes.Count];

            for (int i = 0; i < chapterNodes.Count; ++i)
            {
                chapters[i] = new Chapter();
                chapters[i].Name = chapterNodes[i].SelectSingleNode("/span").InnerText;
                chapters[i].Uri = new Uri(chapterNodes[i].Attributes["href"].ToString());
            }

            return chapters;
        }
        protected Uri[] InitPages(Uri uri)
        {
            string script = Client.GetDocument(uri).DocumentNode.SelectSingleNode("/html/body/script").ToString();

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
        protected string GetDownloadPath()
        {
            string path = Ini.Read("Settings", "DownloadPath", "Settings.ini");
            if (path == "?" || !Directory.Exists("path"))
            {
                Ini.Write("Settings", "DownloadPath", KnownFolders.Downloads.Path, "Settings.ini");
                return KnownFolders.Downloads.Path;
            }
            return path;
        }

        #region 初始化相关，应给 Client 写入权限
        public string Title { get => title; internal set => title = value; }
        public Uri Cover { get => cover; internal set => cover = value; }
        public string UpdateTo { get => updateTo; internal set => updateTo = value; }
        public string Time { get => time; internal set => time = value; }
        internal Uri BookUri { get => bookUri; set => bookUri = value; } // 不应该暴露 Uri 给外部直接访问
        #endregion
    }
}
