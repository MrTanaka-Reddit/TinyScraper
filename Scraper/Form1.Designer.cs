namespace Scraper
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.btnScrape = new System.Windows.Forms.Button();
            this.gridResults = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.rbVideoFilter = new System.Windows.Forms.RadioButton();
            this.rbAudioOnly = new System.Windows.Forms.RadioButton();
            this.rbAllFilter = new System.Windows.Forms.RadioButton();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnSelectNone = new System.Windows.Forms.Button();
            this.btnInverse = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbArchivesOnly = new System.Windows.Forms.RadioButton();
            this.rbDocsOnly = new System.Windows.Forms.RadioButton();
            this.rbImagesOnly = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.btnDuplicates = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblSelected = new System.Windows.Forms.Label();
            this.lblFileCount = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbDepth = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnLoadScrapeFile = new System.Windows.Forms.Button();
            this.btnSaveScrapeFile = new System.Windows.Forms.Button();
            this.saveFileDialogExportDetails = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogImportDetails = new System.Windows.Forms.OpenFileDialog();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblScrapeTime = new System.Windows.Forms.Label();
            this.rbShowGrid = new System.Windows.Forms.RadioButton();
            this.rbShowTree = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tvResults = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.gridResults)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDepth)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbUrl
            // 
            this.tbUrl.Font = new System.Drawing.Font("Segoe UI", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUrl.Location = new System.Drawing.Point(7, 64);
            this.tbUrl.Margin = new System.Windows.Forms.Padding(4);
            this.tbUrl.MinimumSize = new System.Drawing.Size(4, 46);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(1407, 38);
            this.tbUrl.TabIndex = 0;
            // 
            // btnScrape
            // 
            this.btnScrape.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrape.Location = new System.Drawing.Point(1529, 64);
            this.btnScrape.Margin = new System.Windows.Forms.Padding(4);
            this.btnScrape.MinimumSize = new System.Drawing.Size(0, 46);
            this.btnScrape.Name = "btnScrape";
            this.btnScrape.Size = new System.Drawing.Size(259, 46);
            this.btnScrape.TabIndex = 1;
            this.btnScrape.Text = "Scrape";
            this.btnScrape.UseVisualStyleBackColor = true;
            this.btnScrape.Click += new System.EventHandler(this.BtnScrape_Click);
            // 
            // gridResults
            // 
            this.gridResults.AllowUserToAddRows = false;
            this.gridResults.AllowUserToDeleteRows = false;
            this.gridResults.AllowUserToOrderColumns = true;
            this.gridResults.AllowUserToResizeRows = false;
            this.gridResults.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridResults.Location = new System.Drawing.Point(13, 328);
            this.gridResults.Margin = new System.Windows.Forms.Padding(4);
            this.gridResults.Name = "gridResults";
            this.gridResults.RowHeadersVisible = false;
            this.gridResults.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridResults.RowTemplate.Height = 31;
            this.gridResults.ShowEditingIcon = false;
            this.gridResults.Size = new System.Drawing.Size(1544, 821);
            this.gridResults.TabIndex = 2;
            this.gridResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridResults_CellContentClick);
            this.gridResults.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridResults_CellValueChanged);
            this.gridResults.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridResults_DataBindingComplete);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(1562, 1000);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(259, 149);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export Selected URLs";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "txt";
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // rbVideoFilter
            // 
            this.rbVideoFilter.AutoSize = true;
            this.rbVideoFilter.Location = new System.Drawing.Point(17, 72);
            this.rbVideoFilter.Margin = new System.Windows.Forms.Padding(4);
            this.rbVideoFilter.Name = "rbVideoFilter";
            this.rbVideoFilter.Size = new System.Drawing.Size(134, 29);
            this.rbVideoFilter.TabIndex = 5;
            this.rbVideoFilter.Text = "Video Only";
            this.rbVideoFilter.UseVisualStyleBackColor = true;
            this.rbVideoFilter.CheckedChanged += new System.EventHandler(this.rbVideoFilter_CheckedChanged);
            // 
            // rbAudioOnly
            // 
            this.rbAudioOnly.AutoSize = true;
            this.rbAudioOnly.Location = new System.Drawing.Point(17, 107);
            this.rbAudioOnly.Margin = new System.Windows.Forms.Padding(4);
            this.rbAudioOnly.Name = "rbAudioOnly";
            this.rbAudioOnly.Size = new System.Drawing.Size(134, 29);
            this.rbAudioOnly.TabIndex = 6;
            this.rbAudioOnly.Text = "Audio Only";
            this.rbAudioOnly.UseVisualStyleBackColor = true;
            this.rbAudioOnly.CheckedChanged += new System.EventHandler(this.rbAudioOnly_CheckedChanged);
            // 
            // rbAllFilter
            // 
            this.rbAllFilter.AutoSize = true;
            this.rbAllFilter.Checked = true;
            this.rbAllFilter.Location = new System.Drawing.Point(17, 37);
            this.rbAllFilter.Margin = new System.Windows.Forms.Padding(4);
            this.rbAllFilter.Name = "rbAllFilter";
            this.rbAllFilter.Size = new System.Drawing.Size(59, 29);
            this.rbAllFilter.TabIndex = 7;
            this.rbAllFilter.TabStop = true;
            this.rbAllFilter.Text = "All";
            this.rbAllFilter.UseVisualStyleBackColor = true;
            this.rbAllFilter.CheckedChanged += new System.EventHandler(this.rbAllFilter_CheckedChanged);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(25, 272);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(152, 48);
            this.btnSelectAll.TabIndex = 8;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.Location = new System.Drawing.Point(201, 272);
            this.btnSelectNone.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(152, 48);
            this.btnSelectNone.TabIndex = 9;
            this.btnSelectNone.Text = "Select None";
            this.btnSelectNone.UseVisualStyleBackColor = true;
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // btnInverse
            // 
            this.btnInverse.Location = new System.Drawing.Point(376, 272);
            this.btnInverse.Margin = new System.Windows.Forms.Padding(4);
            this.btnInverse.Name = "btnInverse";
            this.btnInverse.Size = new System.Drawing.Size(152, 48);
            this.btnInverse.TabIndex = 10;
            this.btnInverse.Text = "Inv. Selection";
            this.btnInverse.UseVisualStyleBackColor = true;
            this.btnInverse.Click += new System.EventHandler(this.btnInverse_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbArchivesOnly);
            this.groupBox1.Controls.Add(this.rbDocsOnly);
            this.groupBox1.Controls.Add(this.rbImagesOnly);
            this.groupBox1.Controls.Add(this.rbAllFilter);
            this.groupBox1.Controls.Add(this.rbVideoFilter);
            this.groupBox1.Controls.Add(this.rbAudioOnly);
            this.groupBox1.Location = new System.Drawing.Point(1562, 472);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(259, 262);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Types";
            // 
            // rbArchivesOnly
            // 
            this.rbArchivesOnly.AutoSize = true;
            this.rbArchivesOnly.Location = new System.Drawing.Point(16, 218);
            this.rbArchivesOnly.Margin = new System.Windows.Forms.Padding(4);
            this.rbArchivesOnly.Name = "rbArchivesOnly";
            this.rbArchivesOnly.Size = new System.Drawing.Size(159, 29);
            this.rbArchivesOnly.TabIndex = 10;
            this.rbArchivesOnly.Text = "Archives Only";
            this.rbArchivesOnly.UseVisualStyleBackColor = true;
            this.rbArchivesOnly.CheckedChanged += new System.EventHandler(this.rbArchivesOnly_CheckedChanged);
            // 
            // rbDocsOnly
            // 
            this.rbDocsOnly.AutoSize = true;
            this.rbDocsOnly.Location = new System.Drawing.Point(17, 181);
            this.rbDocsOnly.Margin = new System.Windows.Forms.Padding(4);
            this.rbDocsOnly.Name = "rbDocsOnly";
            this.rbDocsOnly.Size = new System.Drawing.Size(182, 29);
            this.rbDocsOnly.TabIndex = 9;
            this.rbDocsOnly.Text = "Documents Only";
            this.rbDocsOnly.UseVisualStyleBackColor = true;
            this.rbDocsOnly.CheckedChanged += new System.EventHandler(this.rbDocsOnly_CheckedChanged);
            // 
            // rbImagesOnly
            // 
            this.rbImagesOnly.AutoSize = true;
            this.rbImagesOnly.Location = new System.Drawing.Point(16, 144);
            this.rbImagesOnly.Margin = new System.Windows.Forms.Padding(4);
            this.rbImagesOnly.Name = "rbImagesOnly";
            this.rbImagesOnly.Size = new System.Drawing.Size(147, 29);
            this.rbImagesOnly.TabIndex = 8;
            this.rbImagesOnly.Text = "Images Only";
            this.rbImagesOnly.UseVisualStyleBackColor = true;
            this.rbImagesOnly.CheckedChanged += new System.EventHandler(this.rbImagesOnly_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFind);
            this.groupBox2.Controls.Add(this.tbFind);
            this.groupBox2.Controls.Add(this.btnDuplicates);
            this.groupBox2.Location = new System.Drawing.Point(1561, 742);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(259, 148);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Refine Results";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(178, 81);
            this.btnFind.Margin = new System.Windows.Forms.Padding(4);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(66, 48);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // tbFind
            // 
            this.tbFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFind.Location = new System.Drawing.Point(17, 81);
            this.tbFind.Margin = new System.Windows.Forms.Padding(4);
            this.tbFind.MinimumSize = new System.Drawing.Size(4, 48);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(154, 39);
            this.tbFind.TabIndex = 1;
            // 
            // btnDuplicates
            // 
            this.btnDuplicates.Location = new System.Drawing.Point(17, 28);
            this.btnDuplicates.Margin = new System.Windows.Forms.Padding(4);
            this.btnDuplicates.Name = "btnDuplicates";
            this.btnDuplicates.Size = new System.Drawing.Size(227, 48);
            this.btnDuplicates.TabIndex = 0;
            this.btnDuplicates.Text = "Remove Duplicates";
            this.btnDuplicates.UseVisualStyleBackColor = true;
            this.btnDuplicates.Click += new System.EventHandler(this.btnDuplicates_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(7, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(1417, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "Depth";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblSelected);
            this.groupBox3.Controls.Add(this.lblFileCount);
            this.groupBox3.Location = new System.Drawing.Point(1564, 897);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(257, 96);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Results";
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelected.Location = new System.Drawing.Point(15, 55);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(91, 30);
            this.lblSelected.TabIndex = 1;
            this.lblSelected.Text = "Selected";
            // 
            // lblFileCount
            // 
            this.lblFileCount.AutoSize = true;
            this.lblFileCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileCount.Location = new System.Drawing.Point(15, 25);
            this.lblFileCount.Name = "lblFileCount";
            this.lblFileCount.Size = new System.Drawing.Size(53, 30);
            this.lblFileCount.TabIndex = 0;
            this.lblFileCount.Text = "Files";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(13, 1153);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(153, 25);
            this.lblStatus.TabIndex = 18;
            this.lblStatus.Text = "Status: Stopped";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbDepth);
            this.groupBox4.Controls.Add(this.tbUrl);
            this.groupBox4.Controls.Add(this.btnScrape);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(18, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1803, 123);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Scrape from Web";
            // 
            // tbDepth
            // 
            this.tbDepth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDepth.Location = new System.Drawing.Point(1422, 64);
            this.tbDepth.Name = "tbDepth";
            this.tbDepth.Size = new System.Drawing.Size(100, 37);
            this.tbDepth.TabIndex = 21;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnLoadScrapeFile);
            this.groupBox5.Controls.Add(this.btnSaveScrapeFile);
            this.groupBox5.Location = new System.Drawing.Point(18, 142);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1803, 100);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Save and Load Scrape";
            // 
            // btnLoadScrapeFile
            // 
            this.btnLoadScrapeFile.Location = new System.Drawing.Point(275, 28);
            this.btnLoadScrapeFile.Name = "btnLoadScrapeFile";
            this.btnLoadScrapeFile.Size = new System.Drawing.Size(246, 65);
            this.btnLoadScrapeFile.TabIndex = 20;
            this.btnLoadScrapeFile.Text = "Load Scrape File";
            this.btnLoadScrapeFile.UseVisualStyleBackColor = true;
            this.btnLoadScrapeFile.Click += new System.EventHandler(this.btnLoadScrapeFile_Click);
            // 
            // btnSaveScrapeFile
            // 
            this.btnSaveScrapeFile.Location = new System.Drawing.Point(7, 29);
            this.btnSaveScrapeFile.Name = "btnSaveScrapeFile";
            this.btnSaveScrapeFile.Size = new System.Drawing.Size(246, 65);
            this.btnSaveScrapeFile.TabIndex = 0;
            this.btnSaveScrapeFile.Text = "Save Scrape File";
            this.btnSaveScrapeFile.UseVisualStyleBackColor = true;
            this.btnSaveScrapeFile.Click += new System.EventHandler(this.btnSaveScrapeFile_Click);
            // 
            // saveFileDialogExportDetails
            // 
            this.saveFileDialogExportDetails.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialogExportDetails_FileOk);
            // 
            // openFileDialogImportDetails
            // 
            this.openFileDialogImportDetails.FileName = "openFileDialog1";
            this.openFileDialogImportDetails.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogImportDetails_FileOk);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            // 
            // lblScrapeTime
            // 
            this.lblScrapeTime.AutoSize = true;
            this.lblScrapeTime.Location = new System.Drawing.Point(13, 1178);
            this.lblScrapeTime.Name = "lblScrapeTime";
            this.lblScrapeTime.Size = new System.Drawing.Size(0, 25);
            this.lblScrapeTime.TabIndex = 20;
            // 
            // rbShowGrid
            // 
            this.rbShowGrid.AutoSize = true;
            this.rbShowGrid.Checked = true;
            this.rbShowGrid.Location = new System.Drawing.Point(14, 28);
            this.rbShowGrid.Name = "rbShowGrid";
            this.rbShowGrid.Size = new System.Drawing.Size(128, 29);
            this.rbShowGrid.TabIndex = 21;
            this.rbShowGrid.TabStop = true;
            this.rbShowGrid.Text = "Show Grid";
            this.rbShowGrid.UseVisualStyleBackColor = true;
            this.rbShowGrid.CheckedChanged += new System.EventHandler(this.rbShowGrid_CheckedChanged);
            // 
            // rbShowTree
            // 
            this.rbShowTree.AutoSize = true;
            this.rbShowTree.Location = new System.Drawing.Point(14, 63);
            this.rbShowTree.Name = "rbShowTree";
            this.rbShowTree.Size = new System.Drawing.Size(133, 29);
            this.rbShowTree.TabIndex = 22;
            this.rbShowTree.Text = "Show Tree";
            this.rbShowTree.UseVisualStyleBackColor = true;
            this.rbShowTree.CheckedChanged += new System.EventHandler(this.rbShowTree_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbShowGrid);
            this.groupBox6.Controls.Add(this.rbShowTree);
            this.groupBox6.Location = new System.Drawing.Point(1564, 328);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(257, 107);
            this.groupBox6.TabIndex = 23;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Display Options";
            // 
            // tvResults
            // 
            this.tvResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvResults.CheckBoxes = true;
            this.tvResults.Location = new System.Drawing.Point(13, 328);
            this.tvResults.Name = "tvResults";
            this.tvResults.Size = new System.Drawing.Size(1544, 821);
            this.tvResults.TabIndex = 24;
            this.tvResults.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvResults_AfterCheck);
            this.tvResults.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvResults_AfterCollapse);
            this.tvResults.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvResults_AfterExpand);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1833, 1206);
            this.Controls.Add(this.tvResults);
            this.Controls.Add(this.lblScrapeTime);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnInverse);
            this.Controls.Add(this.btnSelectNone);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.gridResults);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Tiny Scraper";
            ((System.ComponentModel.ISupportInitialize)(this.gridResults)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDepth)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Button btnScrape;
        private System.Windows.Forms.DataGridView gridResults;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.RadioButton rbVideoFilter;
        private System.Windows.Forms.RadioButton rbAudioOnly;
        private System.Windows.Forms.RadioButton rbAllFilter;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnSelectNone;
        private System.Windows.Forms.Button btnInverse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDuplicates;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Label lblFileCount;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnSaveScrapeFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialogExportDetails;
        private System.Windows.Forms.Button btnLoadScrapeFile;
        private System.Windows.Forms.OpenFileDialog openFileDialogImportDetails;
        private System.Windows.Forms.NumericUpDown tbDepth;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Label lblScrapeTime;
        private System.Windows.Forms.RadioButton rbImagesOnly;
        private System.Windows.Forms.RadioButton rbDocsOnly;
        private System.Windows.Forms.RadioButton rbArchivesOnly;
        private System.Windows.Forms.RadioButton rbShowGrid;
        private System.Windows.Forms.RadioButton rbShowTree;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TreeView tvResults;
    }
}

