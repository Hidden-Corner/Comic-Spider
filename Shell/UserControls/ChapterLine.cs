using System.Windows.Forms;
using GuFengApi;
using Shell.Subforms;

namespace Shell.UserControls
{
    public partial class ChapterLine : UserControl
    {
        Book.Chapter chapter;
        string title;
        int rank;

        public ChapterLine(Book.Chapter chapter, int rank, string title)
        {
            InitializeComponent();
            this.chapterName.Text = chapter.Name;
            this.rank = rank;
            this.chapter = chapter;
            this.title = title;
        }

        private void btnDownload_Click(object sender, System.EventArgs e)
        {

            Download.SingleTask task = new Download.SingleTask(chapter, title + "/" + chapter.Name);
            Program.MainForm.fDownload.AddTask(task);
        }
    }
}
