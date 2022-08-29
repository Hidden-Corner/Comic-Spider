using System.Windows.Forms;
using System.Drawing;
using GuFengApi;

namespace Shell.UserControls
{
    public partial class BookPreview : UserControl
    {
        Book book;

        public BookPreview(Book book)
        {
            InitializeComponent();
            this.cover.Image = Image.FromFile(Program.Cache.ReadCache(book.Cover));
            this.title.Text = book.Title;
            this.updateTime.Text = book.Time;
            this.updateTo.Text = book.UpdateTo;
            this.book = book;
        }

        ~BookPreview()
        {
            cover.Image.Dispose();
            Dispose(true);
        }

        private void cover_Click(object sender, System.EventArgs e)
        {
            Program.MainForm.fHome.OpenDetail(book);
        }
    }
}
