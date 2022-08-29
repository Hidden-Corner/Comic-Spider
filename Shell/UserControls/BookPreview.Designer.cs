namespace Shell.UserControls
{
    partial class BookPreview
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
            this.cover = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            this.updateTime = new System.Windows.Forms.Label();
            this.updateTo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cover)).BeginInit();
            this.SuspendLayout();
            // 
            // cover
            // 
            this.cover.Location = new System.Drawing.Point(3, 3);
            this.cover.Name = "cover";
            this.cover.Size = new System.Drawing.Size(140, 186);
            this.cover.TabIndex = 0;
            this.cover.TabStop = false;
            this.cover.Click += new System.EventHandler(this.cover_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title.Location = new System.Drawing.Point(4, 196);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(38, 20);
            this.title.TabIndex = 1;
            this.title.Text = "Title";
            // 
            // updateTime
            // 
            this.updateTime.AutoSize = true;
            this.updateTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.updateTime.Location = new System.Drawing.Point(5, 216);
            this.updateTime.Name = "updateTime";
            this.updateTime.Size = new System.Drawing.Size(79, 17);
            this.updateTime.TabIndex = 2;
            this.updateTime.Text = "UpdateTime";
            // 
            // updateTo
            // 
            this.updateTo.AutoSize = true;
            this.updateTo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.updateTo.Location = new System.Drawing.Point(5, 233);
            this.updateTo.Name = "updateTo";
            this.updateTo.Size = new System.Drawing.Size(64, 17);
            this.updateTo.TabIndex = 3;
            this.updateTo.Text = "updateTo";
            // 
            // BookPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.updateTo);
            this.Controls.Add(this.updateTime);
            this.Controls.Add(this.title);
            this.Controls.Add(this.cover);
            this.Name = "BookPreview";
            this.Size = new System.Drawing.Size(146, 253);
            ((System.ComponentModel.ISupportInitialize)(this.cover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox cover;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label updateTime;
        private System.Windows.Forms.Label updateTo;
    }
}
