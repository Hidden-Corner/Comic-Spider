// Copyright (c) 2022 Hidden Corner. All rights reserved.

using HtmlAgilityPack;
using ProgressBarSolution;
using System;
using System.IO;
using System.Net;
using System.Threading;

namespace ComicSpider
{
    public class Program
    {
        public const string url = "https://www.gufengmh9.com";
        public const string resUrl = "https://res.xiaoqinre.com";
        private const string save = "C:\\Users\\ASUS\\Downloads";
        private static uint count = 0;
        private static uint totalCount = 0;

        static void Main()
        {
            // 查询
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("ComicSpider v1.0 by Hidden Corner\n");
            Console.Write("关键词：");
            string name = Console.ReadLine();

            // 列出书籍数量
            Console.Clear();
            HtmlDocument doc = GetDocument(url + "/search/?keywords=" + name);
            HtmlNode search = doc.DocumentNode.SelectSingleNode("//div[@class = 'bar-tab book-sort']/h4");
            Console.WriteLine(search.InnerText);
            HtmlNodeCollection bookList = doc.DocumentNode.SelectNodes("//div[@id = 'w0']/ul/li/a");
            HtmlNodeCollection updateList = doc.DocumentNode.SelectNodes("//div[@id = 'w0']/ul/li/a/span[@class = 'tt']");

            if (bookList != null)
            {
                // 询问书籍
                for (int i = 0; i < bookList.Count; i++)
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine($"{i + 1}：");
                    Console.WriteLine(bookList[i].Attributes["title"].Value);
                    Console.WriteLine(updateList[i].InnerText);
                    Console.WriteLine(bookList[i].Attributes["href"].Value);
                }
                updateList.Clear();
                Console.WriteLine("--------------------------------");
                Console.Write("要爬取的书籍序号：");
                int select = int.Parse(Console.ReadLine());
                --select;

                // 设置线程数
                Console.Write("下载线程数：");
                uint threads = uint.Parse(Console.ReadLine());
                ServicePointManager.DefaultConnectionLimit = (int)threads * 2;

                // 获取目录信息
                Console.Clear();
                Console.WriteLine("初始化目录信息. . .");
                Console.Write("尝试获取HtmlDocument. . .");
                Book book = new Book(bookList[select].Attributes["title"].Value, GetDocument(bookList[select].Attributes["href"].Value), threads);
                bookList.Clear();
                Console.Clear();
                if (!Directory.Exists($"{save}\\ComicSpider"))
                    Directory.CreateDirectory($"{save}\\ComicSpider");
                if (!Directory.Exists($"{save}\\ComicSpider\\{book.title}"))
                    Directory.CreateDirectory($"{save}\\ComicSpider\\{book.title}");

                // 下载
                Console.Clear();
                Console.CursorLeft = 0;
                Console.CursorTop = 2;
                Console.WriteLine("总进度");
                ProgressBar totalBar = new ProgressBar(0, 3);
                for (int i = 0; i < book.chapters.Length; ++i)
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = 0;
                    Console.Write("                                                            ");
                    Console.CursorLeft = 0;
                    Console.WriteLine($"正在下载章节 \"{book.chapters[i].title}\". . .");
                    if (!Directory.Exists($"{save}\\ComicSpider\\{book.title}\\{book.chapters[i].title}"))
                        Directory.CreateDirectory($"{save}\\ComicSpider\\{book.title}\\{book.chapters[i].title}");
                    Thread[] ts = new Thread[threads];
                    for (int j = 0; j < threads; ++j)
                    {
                        ts[j] = new Thread(DownloadThread);
                        ts[j].Start(new ThreadParameter(j, ts.Length, $"{save}\\ComicSpider\\{book.title}\\{book.chapters[i].title}", book.chapters[i].pages));
                    }
                    ProgressBar bar = new ProgressBar();
                    count = 0;
                    while (!AllFinish(ts))
                    {
                        bar.Display((int)(count * 100 / book.chapters[i].pages.Length));
                        totalBar.Display((int)(totalCount * 100 / book.totalPage));
                        Thread.Sleep(500);
                    }
                    bar.Display(100);
                }
                totalBar.Display(100);
                GC.Collect();
                Console.WriteLine("\n所有任务都完成了！\a");
            }
            else
            {
                Console.WriteLine("\nError: 没有找到任何书籍！");
            }
            Console.WriteLine("按下任意键退出. . .");
            Console.ReadKey();
        }

        public static HtmlDocument GetDocument(string url)
        {
        again:
            try
            {
                HttpWebRequest http = (HttpWebRequest)WebRequest.Create(url);
                http.Method = "GET";
                http.KeepAlive = false;
                http.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
                http.Referer = $"{url}/";
                HttpWebResponse response;
                response = (HttpWebResponse)http.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(reader.ReadToEnd());
                response.Close();
                stream.Close();
                return doc;
            }
            catch (WebException ex)
            {
                if ((ex.Response as HttpWebResponse).StatusCode != HttpStatusCode.BadGateway && System.Windows.Forms.MessageBox.Show($"在 GetDocument 中发生异常！\n如果异常反复出现，建议检查一下网络连接，或联系作者以获得技术帮助。\n错误信息：{ex.Message}\n错误地址：{url}", "发生错误", System.Windows.Forms.MessageBoxButtons.RetryCancel, System.Windows.Forms.MessageBoxIcon.Error) != System.Windows.Forms.DialogResult.Retry)
                    Environment.Exit(1);
                goto again;
            }
        }

        static void Download(string url, string path)
        {
            uint failedCount = 0;
            int timeout = 2000;
        again:
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
                request.Referer = "https://www.gufengmh9.com/";
                request.Timeout = timeout;
                Stream stream = request.GetResponse().GetResponseStream();
                FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(file);
                byte[] buffer = new byte[1024];
                int size = stream.Read(buffer, 0, buffer.Length);
                while (size > 0)
                {
                    bw.Write(buffer, 0, size);
                    size = stream.Read(buffer, 0, buffer.Length);
                }
                file.Close();
                stream.Close();
            }
            catch (WebException ex)
            {
                ++failedCount;
                if (failedCount % 5 == 0)
                {
                    if (timeout * 4 < 0 && timeout != int.MaxValue && timeout != Timeout.Infinite)
                    {
                        timeout = int.MaxValue;
                    }
                    else if (timeout == int.MaxValue)
                    {
                        timeout = Timeout.Infinite;
                    }
                    else if (timeout == Timeout.Infinite)
                    {
                        System.Windows.Forms.MessageBox.Show($"侦测到有文件多次下载失败！本线程即将临时挂起. . .\n下载路径：\"{path}\"\n请求地址：\"{url}\"\n错误次数：\"{failedCount}\"\n异常信息：{ex.Message}", "下载失败", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                        Thread.Sleep(1000);
                    }
                    else
                        timeout *= 4;
                }
                if ((ex.Response as HttpWebResponse).StatusCode == HttpStatusCode.NotFound)
                {
                    // 待实现. . .
                    System.Windows.Forms.MessageBox.Show($"没能找到文件 {url}！\n按下中止结束下载，", "404 Not Found", System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore, System.Windows.Forms.MessageBoxIcon.Error);
                    Environment.Exit(1);
                }
                if (ex.Status != WebExceptionStatus.Timeout && System.Windows.Forms.MessageBox.Show($"有未知的异常发生！\n如果该异常反复出现，请联系 Corner (Hidden_Corner@outlook.com) 以获得帮助。\n下载路径：\"{path}\"\n请求地址：\"{url}\"\n错误次数：\"{failedCount}\"\n异常源：{ex.Source}\n异常信息：{ex.Message}", "下载失败", System.Windows.Forms.MessageBoxButtons.RetryCancel, System.Windows.Forms.MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Cancel)
                    Environment.Exit(1);
                goto again;
            }
            catch (Exception ex)
            {
                if (System.Windows.Forms.MessageBox.Show($"有未知的异常发生！\n如果该异常反复出现，请联系 Corner (Hidden_Corner@outlook.com) 以获得帮助。\n下载路径：\"{path}\"\n请求地址：\"{url}\"\n错误次数：\"{failedCount}\"\n异常源：{ex.Source}\n异常信息：{ex.Message}", "下载失败", System.Windows.Forms.MessageBoxButtons.RetryCancel, System.Windows.Forms.MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Cancel)
                    Environment.Exit(1);
                goto again;
            }
        }

        static void DownloadThread(object obj)
        {
            ThreadParameter param = obj as ThreadParameter;
            for (int i = 0; i * param.tt + param.rank < param.urls.Length; ++i)
            {
                Download(param.urls[i * param.tt + param.rank], $"{param.savePath}\\{i * param.tt + param.rank + 1}.jpg");
                ++count;
                ++totalCount;
            }
        }

        static bool AllFinish(Thread[] t)
        {
            for (int i = 0; i < t.Length; i++)
                if (t[i].IsAlive)
                    return false;
            return true;
        }
    }
}
