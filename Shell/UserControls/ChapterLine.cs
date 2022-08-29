using System.Windows.Forms;
using GuFengApi;

namespace Shell.UserControls
{
    public partial class ChapterLine : UserControl
    {
        public ChapterLine(Book.Chapter chapter)
        {
            InitializeComponent();
            this.chapterName.Text = chapter.Name;
        }
    }
}
