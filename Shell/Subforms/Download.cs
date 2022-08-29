using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        public class Task
        {
            Book book;
            int[] ranks;
            int thread; // 负责下载该 Task 的线程序号
            DownloadTaskLine dtl;

            public Task(Book book, int[] ranks)
            {
                this.Book = book;
                this.Ranks = ranks;
            }

            public Book Book { get => book; set => book = value; }
            public int[] Ranks { get => ranks; set => ranks = value; }
            public int Thread { get => thread; internal set => thread = value; }
            public DownloadTaskLine Dtl { get => dtl; set => dtl = value; }
        }

        List<Task> taskList = new List<Task>();

        public Download(int threadAvaliable)
        {
            InitializeComponent();
            downloaders = new Thread[threadAvaliable];
            maintainer = new Thread(new ThreadStart(MaintainQueue));
            maintainer.Start();
        }

        #region 多线程下载与任务维护

        public void AddTask(Task task)
        {
            task.Dtl = new DownloadTaskLine(task.Book.Title);
            task.Dtl.Dock = DockStyle.Top;
            task.Dtl.progressBar.Visible = false;
            gbDownload.Controls.Add(task.Dtl);
            taskList.Add(task);
        }

        /// <summary>
        /// 下载 守护线程
        /// </summary>
        protected void MaintainQueue()
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (taskList.Count > 0)
                {
                    for (int i = 0; i < downloaders.Length; ++i)
                    {
                        if (downloaders[i] == null)
                        {
                            Task ready = taskList.First();
                            ready.Thread = i;
                            taskList.Remove(taskList.First());
                            downloaders[i] = new Thread(new ParameterizedThreadStart(DownloadTask));
                            downloaders[i].Start(ready);
                        }
                    }
                }
            }
        }

        protected void DownloadTask(object pak)
        {
            (pak as Task).Dtl.progressBar.Visible = true;
            for (int i = 0; i < (pak as Task).Ranks.Length; ++i)
            {
                (pak as Task).Book.DownloadSingleChapter((pak as Task).Ranks[i]);
                (pak as Task).Dtl.progressBar.Value = i * 100 / (pak as Task).Ranks.Length;
            }
            gbDownload.Controls.Remove((pak as Task).Dtl);
            downloaders[(pak as Task).Thread] = null;
        }
        #endregion
    }
}
