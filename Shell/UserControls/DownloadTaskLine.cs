using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shell.UserControls
{
    public partial class DownloadTaskLine : UserControl
    {
        public DownloadTaskLine(string name)
        {
            InitializeComponent();
            taskName.Text = name;
        }
    }
}
