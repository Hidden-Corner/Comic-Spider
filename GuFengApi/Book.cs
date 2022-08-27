using System;
using HtmlAgilityPack;

namespace GuFengApi
{
    public class Book
    {
        string title;
        Uri cover;
        string updateTo; // 更新到哪个章节
        string time; // 最后更新时间
        Uri bookUri;

        public class Chapter
        {
            string name;
            Uri uri;
            Uri[] pages;

            public string Name { get => name; internal set => name = value; }
            public Uri[] Pages { get => pages; internal set => pages = value; }
            public Uri Uri { get => uri; internal set => uri = value; }
            public int Count => Pages.Length;
        }

        Chapter[] chapters;

        public void DownloadTo(string path)
        {
            if (chapters == null)
                chapters = InitChapters();
            for (int i = 0; i < chapters.Length; ++i)
            {
                DownloadSingleChapterTo(i, path);
            }
        }

        public void DownloadSingleChapterTo(int rank, string path)
        {
            if (chapters == null)
                chapters = InitChapters();
            if (chapters[rank].Pages == null)
                chapters[rank].Pages = InitPages(chapters[rank].Uri);
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
            string script = Client.GetDocument(uri).DocumentNode.SelectSingleNode("/body/script").ToString();
        }

        // 初始化相关，应给 Client 写入权限
        public string Title { get => title; internal set => title = value; }
        public Uri Cover { get => cover; internal set => cover = value; }
        public string UpdateTo { get => updateTo; internal set => updateTo = value; }
        public string Time { get => time; internal set => time = value; }
        internal Uri BookUri { get => bookUri; set => bookUri = value; }
    }
}
