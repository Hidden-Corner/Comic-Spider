namespace Shell.Subforms
{
    partial class Download
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
            this.gbDownload = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // gbDownload
            // 
            this.gbDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDownload.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbDownload.Location = new System.Drawing.Point(12, 12);
            this.gbDownload.Name = "gbDownload";
            this.gbDownload.Size = new System.Drawing.Size(676, 476);
            this.gbDownload.TabIndex = 1;
            this.gbDownload.TabStop = false;
            this.gbDownload.Text = "这里会显示正在下载的任务";
            // 
            // Download
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.gbDownload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Download";
            this.Text = "FormDownload";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDownload;
    }
}