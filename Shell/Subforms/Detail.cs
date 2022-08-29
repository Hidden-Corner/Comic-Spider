using System.Windows.Forms;
using GuFengApi;
using System.Drawing;

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
        }

        private void btnBackwards_Click(object sender, System.EventArgs e)
        {
            Program.MainForm.fHome.fDetail = null;
            this.Hide();
            Parent.Show();
            Dispose();
        }
    }
}
