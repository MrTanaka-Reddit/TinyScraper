namespace Scraper
{
    partial class fmOpenScrapeFile
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
            this.lbScrapeFiles = new System.Windows.Forms.ListBox();
            this.BtnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.llManageScrapeFiles = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lbScrapeFiles
            // 
            this.lbScrapeFiles.FormattingEnabled = true;
            this.lbScrapeFiles.ItemHeight = 24;
            this.lbScrapeFiles.Location = new System.Drawing.Point(26, 30);
            this.lbScrapeFiles.Name = "lbScrapeFiles";
            this.lbScrapeFiles.Size = new System.Drawing.Size(753, 316);
            this.lbScrapeFiles.TabIndex = 0;
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(639, 367);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(140, 52);
            this.BtnOk.TabIndex = 1;
            this.BtnOk.Text = "Ok";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(480, 367);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 52);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // llManageScrapeFiles
            // 
            this.llManageScrapeFiles.AutoSize = true;
            this.llManageScrapeFiles.Location = new System.Drawing.Point(26, 367);
            this.llManageScrapeFiles.Name = "llManageScrapeFiles";
            this.llManageScrapeFiles.Size = new System.Drawing.Size(198, 25);
            this.llManageScrapeFiles.TabIndex = 3;
            this.llManageScrapeFiles.TabStop = true;
            this.llManageScrapeFiles.Text = "Manage Scrape Files";
            this.llManageScrapeFiles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llManageScrapeFiles_LinkClicked);
            // 
            // fmOpenScrapeFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.llManageScrapeFiles);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.lbScrapeFiles);
            this.Name = "fmOpenScrapeFile";
            this.Text = "Open Scrape File";
            this.Load += new System.EventHandler(this.fmOpenScrapeFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbScrapeFiles;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.LinkLabel llManageScrapeFiles;
    }
}