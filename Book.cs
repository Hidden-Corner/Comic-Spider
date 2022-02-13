// Book.cs by Hidden Corner
// Book 类实现

using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicSpider
{
    internal class Book
    {
        public uint totalPage;
        public string title;
        public HtmlDocument doc;

        internal class Chapter
        {
            public string title;
            public string[] pages;
        }

        public Chapter[] chapters;

        public Book(string title, HtmlDocument doc, uint threads)
        {
            this.title = title;
            this.doc = doc;
            totalPage = 0;

            ProgressBarSolution.ProgressBar bar = new ProgressBarSolution.ProgressBar(0, 1);

            HtmlNodeCollection cTitle = doc.DocumentNode.SelectNodes("//div[@class = 'chapter-body clearfix']/ul/li/a/span");
            HtmlNodeCollection cPage = doc.DocumentNode.SelectNodes("//div[@class = 'chapter-body clearfix']/ul/li/a");

            chapters = new Chapter[cTitle.Count];
            for (int i = 0; i < cTitle.Count; i++)
            {
                bar.Display((i + 1) * 100 / cTitle.Count);
                chapters[i] = new Chapter();
                chapters[i].title = ProcessTitle(cTitle[i].InnerText);
                string script = Program.GetDocument(Program.url + cPage[i].Attributes["href"].Value).DocumentNode.SelectSingleNode("/html/body/script").InnerText;
                MatchCollection matches = Regex.Matches(Regex.Match(script, @"var chapterImages = \[.*\]").Value, @"[^\""]+\.jpg");
                chapters[i].pages = new string[matches.Count];
                totalPage += (uint)matches.Count;
                string imgPath = Regex.Match(script, @"images/comic/[0-9]+/[0-9]+/").Value;
                for (int j = 0; j < matches.Count; j++)
                {
                    chapters[i].pages[j] = Program.resUrl + "/" + imgPath + matches[j].Value;
                }
            }

            bar.Display(100);

            cTitle.Clear();
            cPage.Clear();

            System.GC.Collect();
        }

        static private string ProcessTitle(string t)
        {
            string str = t;
            for (int i = str.Length - 1; i >= 0; i--)
                if (str[i] == '.')
                    str = str.Substring(0, i);
                else
                    break;
            return str;
        }
    }
}
