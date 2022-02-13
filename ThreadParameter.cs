using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicSpider
{
    internal class ThreadParameter
    {
        public int rank;
        public int tt;
        public string savePath;
        public string[] urls;

        public ThreadParameter(int rank, int tt, string savePath, string[] urls)
        {
            this.rank = rank;
            this.tt = tt;
            this.savePath = savePath;
            this.urls = urls;
        }
    }
}
