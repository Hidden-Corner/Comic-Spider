namespace Shell.Subforms
{
    partial class Detail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBackwards = new FontAwesome.Sharp.IconButton();
            this.bookCover = new System.Windows.Forms.PictureBox();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.labelArtist = new System.Windows.Forms.Label();
            this.labelDetail = new System.Windows.Forms.Label();
            this.btnDownload = new FontAwesome.Sharp.IconButton();
            this.btnStar = new FontAwesome.Sharp.IconButton();
            this.btnReadOnline = new FontAwesome.Sharp.IconButton();
            this.bookName = new System.Windows.Forms.Label();
            this.panelChapter = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.bookCover)).BeginInit();
            this.panelDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBackwards
            // 
            this.btnBackwards.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.btnBackwards.IconColor = System.Drawing.SystemColors.HotTrack;
            this.btnBackwards.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBackwards.IconSize = 30;
            this.btnBackwards.Location = new System.Drawing.Point(12, 12);
            this.btnBackwards.Name = "btnBackwards";
            this.btnBackwards.Size = new System.Drawing.Size(30, 30);
            this.btnBackwards.TabIndex = 0;
            this.btnBackwards.UseVisualStyleBackColor = true;
            this.btnBackwards.Click += new System.EventHandler(this.btnBackwards_Click);
            // 
            // bookCover
            // 
            this.bookCover.Location = new System.Drawing.Point(3, 3);
            this.bookCover.Name = "bookCover";
            this.bookCover.Size = new System.Drawing.Size(120, 180);
            this.bookCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bookCover.TabIndex = 1;
            this.bookCover.TabStop = false;
            // 
            // panelDetail
            // 
            this.panelDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDetail.Controls.Add(this.labelArtist);
            this.panelDetail.Controls.Add(this.labelDetail);
            this.panelDetail.Controls.Add(this.btnDownload);
            this.panelDetail.Controls.Add(this.btnStar);
            this.panelDetail.Controls.Add(this.btnReadOnline);
            this.panelDetail.Controls.Add(this.bookName);
            this.panelDetail.Controls.Add(this.bookCover);
            this.panelDetail.Location = new System.Drawing.Point(12, 48);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(676, 187);
            this.panelDetail.TabIndex = 2;
            // 
            // labelArtist
            // 
            this.labelArtist.AutoSize = true;
            this.labelArtist.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelArtist.Location = new System.Drawing.Point(135, 38);
            this.labelArtist.Name = "labelArtist";
            this.labelArtist.Size = new System.Drawing.Size(44, 20);
            this.labelArtist.TabIndex = 7;
            this.labelArtist.Text = "Artist";
            // 
            // labelDetail
            // 
            this.labelDetail.AutoSize = true;
            this.labelDetail.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDetail.Location = new System.Drawing.Point(135, 58);
            this.labelDetail.Name = "labelDetail";
            this.labelDetail.Size = new System.Drawing.Size(84, 20);
            this.labelDetail.TabIndex = 6;
            this.labelDetail.Text = "bookDetail";
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnDownload.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDownload.ForeColor = System.Drawing.Color.White;
            this.btnDownload.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnDownload.IconColor = System.Drawing.Color.White;
            this.btnDownload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDownload.IconSize = 25;
            this.btnDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownload.Location = new System.Drawing.Point(347, 148);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(100, 35);
            this.btnDownload.TabIndex = 5;
            this.btnDownload.Text = "全册下载";
            this.btnDownload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnStar
            // 
            this.btnStar.BackColor = System.Drawing.Color.Gold;
            this.btnStar.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStar.ForeColor = System.Drawing.Color.White;
            this.btnStar.IconChar = FontAwesome.Sharp.IconChar.Star;
            this.btnStar.IconColor = System.Drawing.Color.White;
            this.btnStar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStar.IconSize = 25;
            this.btnStar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStar.Location = new System.Drawing.Point(241, 148);
            this.btnStar.Name = "btnStar";
            this.btnStar.Size = new System.Drawing.Size(100, 35);
            this.btnStar.TabIndex = 4;
            this.btnStar.Text = "加入收藏";
            this.btnStar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStar.UseVisualStyleBackColor = false;
            this.btnStar.Click += new System.EventHandler(this.btnStar_Click);
            // 
            // btnReadOnline
            // 
            this.btnReadOnline.BackColor = System.Drawing.Color.Red;
            this.btnReadOnline.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReadOnline.ForeColor = System.Drawing.Color.White;
            this.btnReadOnline.IconChar = FontAwesome.Sharp.IconChar.Book;
            this.btnReadOnline.IconColor = System.Drawing.Color.White;
            this.btnReadOnline.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReadOnline.IconSize = 25;
            this.btnReadOnline.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReadOnline.Location = new System.Drawing.Point(135, 148);
            this.btnReadOnline.Name = "btnReadOnline";
            this.btnReadOnline.Size = new System.Drawing.Size(100, 35);
            this.btnReadOnline.TabIndex = 3;
            this.btnReadOnline.Text = "在线阅读";
            this.btnReadOnline.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReadOnline.UseVisualStyleBackColor = false;
            this.btnReadOnline.Click += new System.EventHandler(this.btnReadOnline_Click);
            // 
            // bookName
            // 
            this.bookName.AutoSize = true;
            this.bookName.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bookName.Location = new System.Drawing.Point(129, 3);
            this.bookName.Name = "bookName";
            this.bookName.Size = new System.Drawing.Size(141, 31);
            this.bookName.TabIndex = 2;
            this.bookName.Text = "bookName";
            // 
            // panelChapter
            // 
            this.panelChapter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChapter.AutoScroll = true;
            this.panelChapter.Location = new System.Drawing.Point(12, 242);
            this.panelChapter.Name = "panelChapter";
            this.panelChapter.Size = new System.Drawing.Size(676, 246);
            this.panelChapter.TabIndex = 3;
            // 
            // Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.panelChapter);
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.btnBackwards);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Detail";
            this.Text = "FormDetail";
            ((System.ComponentModel.ISupportInitialize)(this.bookCover)).EndInit();
            this.panelDetail.ResumeLayout(false);
            this.panelDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnBackwards;
        private System.Windows.Forms.PictureBox bookCover;
        private System.Windows.Forms.Panel panelDetail;
        private System.Windows.Forms.Label bookName;
        private System.Windows.Forms.Label labelDetail;
        private FontAwesome.Sharp.IconButton btnDownload;
        private FontAwesome.Sharp.IconButton btnStar;
        private FontAwesome.Sharp.IconButton btnReadOnline;
        private System.Windows.Forms.FlowLayoutPanel panelChapter;
        private System.Windows.Forms.Label labelArtist;
    }
}