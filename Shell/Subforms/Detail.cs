using System.Windows.Forms;
using GuFengApi;
using System.Drawing;
using Shell.UserControls;

namespace Shell.Subforms
{
    public partial class Detail : Form
    {
        Book book;

        public Detail(Book book)
        {
            InitializeComponent();
            this.book = book;
            bookCover.Image = Image.FromFile(Program.Cache.ReadCache(book.Cover));
            bookName.Text = book.Title;

            for(int i = 0; i < book.Chapters.Length; ++i)
            {
                ChapterLine line = new ChapterLine(book.Chapters[i], i, book.Title);
                line.Dock = DockStyle.Top;
                panelChapter.Controls.Add(line);
            }
        }

        private void btnReadOnline_Click(object sender, System.EventArgs e)
        {
            System.Diagnostics.Process.Start(book.BookUri.ToString());
        }

        private void btnStar_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("该功能尚未实现，敬请期待!", "尚未实现", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnDownload_Click(object sender, System.EventArgs e)
        {
            int[] ranks = new int[book.Chapters.Length];
            for (int i = 0; i < book.Chapters.Length; ++i)
            {
                ranks[i] = i;
            }
            Download.MulitTask task = new Download.MulitTask(book, ranks);
            Program.MainForm.fDownload.AddTask(task);
        }

        private void btnBackwards_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            Program.MainForm.fHome.fDetail = null;
            Program.MainForm.fHome.Show();
            bookCover.Image.Dispose();
            panelChapter.Dispose();
            Dispose();
        }
    }
}
