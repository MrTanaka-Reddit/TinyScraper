using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Scraper
{
    public partial class fmOpenScrapeFile : Form
    {
        /// <summary>
        /// Public properties used to record the user's selection.
        /// Used by the calling form to get the selection details.
        /// </summary>
        public string SelectedScrapeFilePath  { get; set; }
        public string SelectedScrapeFileUrl { get; set; }


        public fmOpenScrapeFile()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Retrieves a list of the saved scrape files and presents them to the user
        /// </summary>
        private void fmOpenScrapeFile_Load(object sender, EventArgs e)
        {
            var scrapeFiles = IO.LoadScrapeFiles(Constants.SCRAPEFILE_FOLDER);

            lbScrapeFiles.DataSource = scrapeFiles;
            lbScrapeFiles.DisplayMember = "Url";
            lbScrapeFiles.ValueMember = "FilePath"; 
        }

        /// <summary>
        /// Sets the class properties to the details of the selected scrape file, 
        /// then closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOk_Click(object sender, EventArgs e)
        {
            var selectedItem = lbScrapeFiles.SelectedItem;
            if (selectedItem != null)
            {
                var selectedScrapeFile = (ScrapeFileInfo)selectedItem;
                SelectedScrapeFilePath = selectedScrapeFile.FilePath;
                SelectedScrapeFileUrl = selectedScrapeFile.Url;
            }

            this.Hide();
        }

        /// <summary>
        /// Closes the form without making any changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void llManageScrapeFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("Explorer", Application.StartupPath + "\\" + Constants.SCRAPEFILE_FOLDER);
        }
    }
}
