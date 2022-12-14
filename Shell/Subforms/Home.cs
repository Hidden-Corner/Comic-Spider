using System.Windows.Forms;
using GuFengApi;
using Shell.UserControls;

namespace Shell.Subforms
{
    public partial class Home : Form
    {
        internal Detail fDetail;
        protected BookPreview[] previews;

        public Home()
        {
            InitializeComponent();
        }

        internal void OpenDetail(Book book)
        {
            fDetail = new Detail(book);
            fDetail.TopLevel = false;
            fDetail.Parent = this.Parent;
            fDetail.Dock = DockStyle.Fill;
            this.Hide();
            fDetail.Show();
        }

        internal void RefreshList(string title, Client api)
        {
            if (previews != null)
            {
                foreach (var item in previews)
                {
                    bookList.Controls.Remove(item);
                }
            }

            if (title == null || title == "")
            {
                System.GC.Collect();
                return;
            }

            Book[] result = api.Search(title);
            if (result == null)
                return;

            previews = new BookPreview[result.Length];
            for (int i = 0; i < result.Length; ++i)
            {
                previews[i] = new BookPreview(result[i]);
                bookList.Controls.Add(previews[i]);
            }
        }

        private void Home_VisibleChanged(object sender, System.EventArgs e)
        {
            if (Visible == true && fDetail != null)
            {
                this.Hide();
                fDetail.Show();
            }
        }
    }
}
