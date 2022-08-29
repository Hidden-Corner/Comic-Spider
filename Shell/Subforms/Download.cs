using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using GuFengApi;
using Shell.UserControls;

namespace Shell.Subforms
{
    public partial class Download : Form
    {
        Thread[] downloaders;
        Thread maintainer;

        #region 各种任务分类
        public class Task
        {
            DownloadTaskLine dtl;

            public Task(string title)
            {
                Dtl = new DownloadTaskLine(title);
                Dtl.Dock = DockStyle.Top;
                Dtl.progressBar.Visible = false;
            }

            public DownloadTaskLine Dtl { get => dtl; set => dtl = value; }
        }

        public class MulitTask : Task
        {
            Book book;
            int[] ranks;

            public MulitTask(Book book, int[] ranks) : base(book.Title)
            {
                this.Book = book;
                this.Ranks = ranks;
            }

            public Book Book { get => book; set => book = value; }
            public int[] Ranks { get => ranks; set => ranks = value; }
        }

        public class SingleTask : Task
        {
            Book.Chapter chapter;

            public SingleTask(Book.Chapter chapter, string title) : base(title)
            {
                this.Chapter = chapter;
            }

            public Book.Chapter Chapter { get => chapter; set => chapter = value; }
        }
        #endregion

        List<object> taskList = new List<object>();

        public Download(int threadAvaliable, object mainThread)
        {
            InitializeComponent();
            downloaders = new Thread[threadAvaliable];
            maintainer = new Thread(new ParameterizedThreadStart(MaintainQueue));
            maintainer.Start(mainThread);
        }

        #region 多线程下载与任务维护

        public void AddTask(object task)
        {
            gbDownload.Controls.Add((task as Task).Dtl);
            taskList.Add(task);
        }

        /// <summary>
        /// 下载 守护线程
        /// </summary>
        protected void MaintainQueue(object mainThread)
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (taskList.Count > 0)
                {
                    for (int i = 0; i < downloaders.Length; ++i)
                    {
                        if (downloaders[i] == null || !downloaders[i].IsAlive)
                        {
                            object ready = taskList.First();
                            taskList.Remove(taskList.First());
                            downloaders[i] = new Thread(new ParameterizedThreadStart(DownloadTask));
                            downloaders[i].Start(ready);
                        }
                    }
                }
                if (!(mainThread as Thread).IsAlive)
                    break;
            }
        }

        protected void DownloadTask(object pak)
        {
            (pak as Task).Dtl.progressBar.Visible = true;
            if (pak is MulitTask)
            {
                for (int i = 0; i < (pak as MulitTask).Ranks.Length; ++i)
                {
                    Client.DownloadChapter((pak as MulitTask).Book.Chapters[i], (pak as Task).Dtl.taskName.Text, null);
                    (pak as MulitTask).Dtl.progressBar.Value = (i + 1) * 100 / (pak as MulitTask).Ranks.Length;
                }
            }
            else if (pak is SingleTask)
            {
                Client.DownloadChapter((pak as SingleTask).Chapter, (pak as Task).Dtl.taskName.Text, (pak as Task).Dtl.progressBar);
            }
            gbDownload.Controls.Remove((pak as Task).Dtl);
        }
        #endregion
    }
}
