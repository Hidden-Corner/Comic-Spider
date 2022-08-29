namespace Shell.Subforms
{
    partial class History
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
            this.icon = new FontAwesome.Sharp.IconPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.SuspendLayout();
            // 
            // icon
            // 
            this.icon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.icon.BackColor = System.Drawing.SystemColors.Control;
            this.icon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.icon.IconChar = FontAwesome.Sharp.IconChar.ClockRotateLeft;
            this.icon.IconColor = System.Drawing.SystemColors.ControlText;
            this.icon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icon.IconSize = 100;
            this.icon.Location = new System.Drawing.Point(300, 80);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(100, 100);
            this.icon.TabIndex = 0;
            this.icon.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(178, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "历史功能尚未实现，敬请期待...";
            // 
            // FormHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.icon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormHistory";
            this.Text = "FormHistory";
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox icon;
        private System.Windows.Forms.Label label1;
    }
}