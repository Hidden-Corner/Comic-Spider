namespace Shell.UserControls
{
    partial class ChapterLine
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.chapterName = new System.Windows.Forms.Label();
            this.btnDownload = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // chapterName
            // 
            this.chapterName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chapterName.AutoSize = true;
            this.chapterName.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chapterName.Location = new System.Drawing.Point(3, 10);
            this.chapterName.Name = "chapterName";
            this.chapterName.Size = new System.Drawing.Size(102, 20);
            this.chapterName.TabIndex = 0;
            this.chapterName.Text = "ChapterName";
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDownload.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnDownload.IconColor = System.Drawing.Color.DeepSkyBlue;
            this.btnDownload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDownload.IconSize = 30;
            this.btnDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownload.Location = new System.Drawing.Point(554, 3);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(93, 34);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "下载";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // ChapterLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.chapterName);
            this.Name = "ChapterLine";
            this.Size = new System.Drawing.Size(650, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label chapterName;
        private FontAwesome.Sharp.IconButton btnDownload;
    }
}
