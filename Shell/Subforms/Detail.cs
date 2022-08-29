﻿using System.Windows.Forms;
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

            foreach(var chapter in book.Chapters)
            {
                ChapterLine line = new ChapterLine(chapter);
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
