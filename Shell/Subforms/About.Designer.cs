namespace Shell.Subforms
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.logo = new System.Windows.Forms.PictureBox();
            this.labelLogo = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.groupBoxContact = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelEmailCaption = new System.Windows.Forms.Label();
            this.labelWebsite = new System.Windows.Forms.LinkLabel();
            this.labelWebsiteCaption = new System.Windows.Forms.Label();
            this.textBoxThanks = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.groupBoxContact.SuspendLayout();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(300, 25);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(100, 100);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            // 
            // labelLogo
            // 
            this.labelLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelLogo.AutoSize = true;
            this.labelLogo.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLogo.Location = new System.Drawing.Point(268, 128);
            this.labelLogo.Name = "labelLogo";
            this.labelLogo.Size = new System.Drawing.Size(165, 31);
            this.labelLogo.TabIndex = 1;
            this.labelLogo.Text = "Comic Spider";
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelVersion.Location = new System.Drawing.Point(325, 159);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(50, 17);
            this.labelVersion.TabIndex = 2;
            this.labelVersion.Text = "version";
            // 
            // groupBoxContact
            // 
            this.groupBoxContact.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBoxContact.Controls.Add(this.label1);
            this.groupBoxContact.Controls.Add(this.labelEmailCaption);
            this.groupBoxContact.Controls.Add(this.labelWebsite);
            this.groupBoxContact.Controls.Add(this.labelWebsiteCaption);
            this.groupBoxContact.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxContact.Location = new System.Drawing.Point(146, 179);
            this.groupBoxContact.Name = "groupBoxContact";
            this.groupBoxContact.Size = new System.Drawing.Size(420, 70);
            this.groupBoxContact.TabIndex = 3;
            this.groupBoxContact.TabStop = false;
            this.groupBoxContact.Text = "联系我们";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(64, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hidden_Corner@outlook.com";
            // 
            // labelEmailCaption
            // 
            this.labelEmailCaption.AutoSize = true;
            this.labelEmailCaption.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEmailCaption.Location = new System.Drawing.Point(7, 41);
            this.labelEmailCaption.Name = "labelEmailCaption";
            this.labelEmailCaption.Size = new System.Drawing.Size(51, 20);
            this.labelEmailCaption.TabIndex = 2;
            this.labelEmailCaption.Text = "邮箱：";
            // 
            // labelWebsite
            // 
            this.labelWebsite.AutoSize = true;
            this.labelWebsite.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWebsite.Location = new System.Drawing.Point(64, 21);
            this.labelWebsite.Name = "labelWebsite";
            this.labelWebsite.Size = new System.Drawing.Size(339, 20);
            this.labelWebsite.TabIndex = 1;
            this.labelWebsite.TabStop = true;
            this.labelWebsite.Text = "https://github.com/Hidden-Corner/Comic-Spider";
            this.labelWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GoToWebsite);
            // 
            // labelWebsiteCaption
            // 
            this.labelWebsiteCaption.AutoSize = true;
            this.labelWebsiteCaption.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWebsiteCaption.Location = new System.Drawing.Point(7, 21);
            this.labelWebsiteCaption.Name = "labelWebsiteCaption";
            this.labelWebsiteCaption.Size = new System.Drawing.Size(51, 20);
            this.labelWebsiteCaption.TabIndex = 0;
            this.labelWebsiteCaption.Text = "网站：";
            // 
            // textBoxThanks
            // 
            this.textBoxThanks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxThanks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxThanks.Enabled = false;
            this.textBoxThanks.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxThanks.Location = new System.Drawing.Point(12, 255);
            this.textBoxThanks.Multiline = true;
            this.textBoxThanks.Name = "textBoxThanks";
            this.textBoxThanks.Size = new System.Drawing.Size(676, 233);
            this.textBoxThanks.TabIndex = 4;
            this.textBoxThanks.Text = "谨此以感谢所有对本程序开发有贡献的人士：\r\n    Hidden Corner (Hidden_Corner@outlook.com)";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.textBoxThanks);
            this.Controls.Add(this.groupBoxContact);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelLogo);
            this.Controls.Add(this.logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "About";
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.groupBoxContact.ResumeLayout(false);
            this.groupBoxContact.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Label labelLogo;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.GroupBox groupBoxContact;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelEmailCaption;
        private System.Windows.Forms.LinkLabel labelWebsite;
        private System.Windows.Forms.Label labelWebsiteCaption;
        private System.Windows.Forms.TextBox textBoxThanks;
    }
}