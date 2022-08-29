// Copyright (C) 2022 Hidden Corner
// GuFengApi 核心实现

using System;
using System.IO;
using System.Net;
using System.Security.Policy;
using HtmlAgilityPack;
using static GuFengApi.Book;

namespace GuFengApi
{
    public class Client
    {
        protected static string mainUri;

        /// <summary>
        /// 搜索指定内容
        /// </summary>
        /// <param name="title">搜索标题</param>
        /// <returns>搜索结果</returns>
        public Book[] Search(string title)
        {
            // 获取基本信息
            HtmlDocument doc = GetDocument(new Uri(mainUri + "search/?keywords=" + title));
            HtmlNodeCollection bookRootNodes = doc.DocumentNode.SelectNodes("//ul[@class='book-list clearfix']/li[@class='item-lg']");
            if (bookRootNodes == null)
                return null;

            Book[] books = new Book[bookRootNodes.Count];

            //初始化 books
            for(int i = 0; i < bookRootNodes.Count; ++i)
            {
                books[i] = new Book();
                books[i].Title = bookRootNodes[i].SelectSingleNode("./p/a").InnerText;
                books[i].Cover = new Uri(bookRootNodes[i].SelectSingleNode("./a/img").Attributes["src"].Value.ToString());
                books[i].BookUri = new Uri(bookRootNodes[i].SelectSingleNode("./a").Attributes["href"].Value.ToString());
                books[i].UpdateTo = bookRootNodes[i].SelectSingleNode("./a/span[@class='tt']").InnerText;
                books[i].Time = bookRootNodes[i].SelectSingleNode("./span").InnerText;
            }

            return books;
        }
        /// <summary>
        /// 下载指定二进制文件（使用 GuFengApi 请求头）
        /// </summary>
        /// <param name="uri">请求地址</param>
        /// <param name="path">保存目录</param>
        public static void Download(Uri uri, string path)
        {
            HttpWebRequest request = InitApiHttpRequest(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(file);
            byte[] buffer = new byte[1024];
            int size = stream.Read(buffer, 0, buffer.Length);
            while (size > 0)
            {
                bw.Write(buffer, 0, size);
                size = stream.Read(buffer, 0, buffer.Length);
            }
            bw.Close();
            file.Close();
            stream.Close();
            response.Close();
        }

        /// <summary>
        /// 仅下载指定章节到目录
        /// </summary>
        /// <param name="rank">章节序号</param>
        public static void DownloadChapter(Chapter chapter, string title, System.Windows.Forms.ProgressBar progressBar)
        {
            if (chapter.Pages == null)
                chapter.Pages = Book.InitPages(chapter.Uri);

            using (var target = chapter)
            {
                string path = GetDownloadPath();

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
                    Download(target.Pages[i], $"{path}/{i + 1}.jpg");
                    if (progressBar != null)
                        progressBar.Value = (i + 1) * 100 / target.Pages.Length;
                }
            }
        }

        #region 内部方法
        /// <summary>
        /// 初始化请求头
        /// 使用 GuFengApi 标准请求头
        /// </summary>
        /// <param name="requestUri">请求地址</param>
        /// <returns></returns>
        protected static HttpWebRequest InitApiHttpRequest(Uri requestUri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
            request.Method = "GET";
            request.Timeout = 30000;
            request.UserAgent = $"GuFengViewerLib/{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}";
            request.KeepAlive = false;
            request.Referer = "https://www.123gf.com/";
            return request;
        }
        /// <summary>
        /// 请求网页并转换为 HtmlDocument 格式
        /// </summary>
        /// <param name="htmlUri">请求地址</param>
        /// <returns></returns>
        internal static HtmlDocument GetDocument(Uri htmlUri)
        {
            HttpWebRequest request = InitApiHttpRequest(htmlUri);
        retry:
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(reader.ReadToEnd());
                reader.Close();
                stream.Close();
                response.Close();
                return doc;
            }
            catch(WebException we)
            {
                goto retry;
            }
        }
        #endregion

        #region 初始化
        public Client()
        {
            mainUri = Ini.Read("Settings", "Website", "Settings.ini");
        }

        public Client(string url)
        {
            mainUri = url;
        }
        #endregion
    }
}