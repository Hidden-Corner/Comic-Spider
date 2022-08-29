using System.Windows.Forms;
using GuFengApi;
using Shell.UserControls;

namespace Shell.Subforms
{
    public partial class Home : Form
    {
        internal Detail fDetail;
        protected BookPreview[] previews;
        bool openningSubform = false;

        public Home()
        {
            InitializeComponent();
        }

        internal void OpenDetail(Book book)
        {
            fDetail = new Detail(book);
            fDetail.Parent = this.Parent;
            fDetail.TopLevel = false;
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
                    item.Dispose();
                }
            }

            Book[] result = api.Search(title);
            previews = new BookPreview[result.Length];
            for (int i = 0; i < result.Length; ++i)
            {
                previews[i] = new BookPreview(result[i]);
                bookList.Controls.Add(previews[i]);
            }
        }

        internal new void Show()
        {
            if (fDetail != null)
                fDetail.Show();
            else
                base.Show();
        }
    }
}
