using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Drawing;

namespace Scraper
{
    public partial class Form1 : Form
    {
        #region == GLOBALS ==

        private List<string> _fileList = new List<string>();
        private List<string> _filteredList = new List<string>();
        private string _selectedTreeViewUrls = "";
        private int _selectedNodeCount = 0;

        #endregion

        public Form1()
        {
            InitializeComponent();

            // Default form values
            lblFileCount.Text = Constants.FILE_COUNT_DEFAULT;
            lblSelected.Text = Constants.SELECTED_DEFAULT;
            rbShowTree.Checked = true;
            

            // Setup the treeview control
            tvResults.PathSeparator = "/";
            tvResults.Font = new Font("Segoe UI", 12);
            var images = new ImageList();
            images.Images.Add("folderClosed", Image.FromFile(@"Images\folder_closed.png"));
            images.Images.Add("folderOpen", Image.FromFile(@"Images\folder_open.png"));
            images.Images.Add("file", Image.FromFile(@"Images\file.png"));
            tvResults.ImageList = images;

        }

        #region == EVENTS: MAIN BUTTONS ==

        private async void BtnScrape_Click(object sender, EventArgs e)
        {
            _fileList.Clear();
            gridResults.Refresh();

            tbUrl.Text = Processor.EnsureSlash(tbUrl.Text);

            var userUrl = tbUrl.Text;
            if (userUrl == "") return;

            lblStatus.Text = Constants.SCRAPING_STARTED;
            var scrapeStart = DateTime.Now;

            var depth = Int32.Parse(tbDepth.Text);

            // This is a List<List<string>> collection and basically works as 2-dimensional array.
            // Each List<string> collection in the parent collection contains the folders found at a given depth in the folder heirarchy.
            var folderUrls = new List<List<string>>();

            lblStatus.Text = Constants.PROCESSING_PREFIX + userUrl;

            // Process Urls in the root document.
            var downloader = new Downloader();
            var document = await downloader.GetDocument(userUrl);

            // If no content is downloaded, just quit here.
            if (document == null) return;

            var urls = Processor.GetUrls(document, userUrl);
            
            // Get a list of all the Urls that point to files
            var files = Processor.GetFileUrls(urls);

            // Get a list of all the Urls that point to folders
            var downstreamFolders = Processor.GetOnlyDownstreamFolders(urls, userUrl);

            // Add any folder Urls found in the root document to the collection.
            folderUrls.Add(downstreamFolders);

            var depthCounter = 0;

            // Process all Urls found in the root document and keep processing until we reach the depth entered by the User,
            // or until we've reached the maximum depth in our collection.
            // Todo: This would be cleaner as a recursive function
            while (depthCounter < depth && depthCounter < folderUrls.Count)
            {
                // Stores all Urls in the folder currently being processed
                var folderUrlsInCurrentDoc = new List<string>();

                // Iterate though each folderUrl (which is a html document) and download its contents as a document.
                // Then, get all the Urls that document and separate them into files and folders.
                foreach (var folderUrl in folderUrls[depthCounter])
                {
                    lblStatus.Text = Constants.PROCESSING_PREFIX + folderUrl;

                    document = await downloader.GetDocument(folderUrl);

                    urls = Processor.GetUrls(document, folderUrl);
                    if (urls != null)
                    {
                        files.InsertRange(files.Count, Processor.GetFileUrls(urls));
                        folderUrlsInCurrentDoc.InsertRange(folderUrlsInCurrentDoc.Count, Processor.GetOnlyDownstreamFolders(urls, folderUrl));
                    }
                }

                if (folderUrlsInCurrentDoc.Count > 0)
                {
                    folderUrls.Add(folderUrlsInCurrentDoc);
                }

                depthCounter++;
            }

            // Update the Global variable. Used by other controls to filter results.
            _fileList = files;

            DisplayResults(_fileList);

            // Update the status bar
            lblStatus.Text = Constants.STATUS_STOPPED;
            TimeSpan duration = DateTime.Now - scrapeStart;
            lblScrapeTime.Text = $"{Constants.SCRAPE_TIME_PREFIX} " +
                $"{duration.TotalSeconds} " +
                $"{Constants.SCRAPE_TIME_SUFFIX}";
        }

        /// <summary>
        /// This event is raised when the btnExport button is clicked.
        /// Used to export file of Urls that user has selected
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
        }

        /// <summary>
        /// This event is raised when the btnSaveScrapeFile button is clicked.
        /// Used to save a file containing all Urls returned in the scrape for future reuse
        /// </summary>
        private void btnSaveScrapeFile_Click(object sender, EventArgs e)
        {
            saveFileDialogExportDetails.ShowDialog();
        }

        /// <summary>
        /// This event is raised when the btnLoadScrapeFile button is clicked.
        /// Used to load a file containing the Urls found in a previous scrape
        /// </summary>
        private void btnLoadScrapeFile_Click(object sender, EventArgs e)
        {
            openFileDialogImportDetails.ShowDialog();
        }

        #endregion

        #region == EVENTS: FILTERS ==

        private void rbVideoFilter_CheckedChanged(object sender, EventArgs e)
        {
            var filteredList = new List<string>();

            if (rbVideoFilter.Checked)
            {
                _filteredList = Processor.GetFilesForGivenExtensions(_fileList, Constants.VIDEO_EXTENSIONS);
                DisplayResults(_filteredList);
            }
        }

        private void rbAllFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAllFilter.Checked)
            {
                _filteredList = _fileList;
                DisplayResults(_filteredList);
            }
        }

        private void rbAudioOnly_CheckedChanged(object sender, EventArgs e)
        {
            var filteredList = new List<string>();

            if (rbAudioOnly.Checked)
            {
                _filteredList = Processor.GetFilesForGivenExtensions(_fileList, Constants.AUDIO_EXTENSIONS);
                DisplayResults(_filteredList);
            }
        }

        private void rbImagesOnly_CheckedChanged(object sender, EventArgs e)
        {
            var filteredList = new List<string>();

            if (rbImagesOnly.Checked)
            {
                _filteredList = Processor.GetFilesForGivenExtensions(_fileList, Constants.IMAGE_EXTENSION);
                DisplayResults(_filteredList);
            }
        }

        private void rbDocsOnly_CheckedChanged(object sender, EventArgs e)
        {
            var filteredList = new List<string>();

            if (rbDocsOnly.Checked)
            {
                _filteredList = Processor.GetFilesForGivenExtensions(_fileList, Constants.DOCUMENT_EXTENSIONS);
                DisplayResults(_filteredList);
            }
        }

        private void rbArchivesOnly_CheckedChanged(object sender, EventArgs e)
        {
            var filteredList = new List<string>();

            if (rbArchivesOnly.Checked)
            {
                _filteredList = Processor.GetFilesForGivenExtensions(_fileList, Constants.ARCHIVE_EXTENSIONS);
                DisplayResults(_filteredList);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            var filter = tbFind.Text;

            if (filter != "")
            {
                List<string> filteredList = new List<string>();

                foreach (var url in _filteredList)
                {
                    if (url.ToLower().Contains(filter.ToLower()))
                    {
                        filteredList.Add(url);
                    }
                }

                _filteredList = filteredList;
                DisplayResults(_filteredList);
            }
        }

        private void btnDuplicates_Click(object sender, EventArgs e)
        {
            List<string> filteredList = new List<string>();

            foreach (var url in _filteredList)
            {
                if (!filteredList.Contains(url))
                {
                    filteredList.Add(url);
                }
            }

            _filteredList = filteredList;
            DisplayResults(_filteredList);
        }


        #endregion

        #region == EVENTS: GRID ==


        private void gridResults_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var counter = 0;
            if (gridResults.Rows.Count > 0)
            {
                for (int i = 0; i < gridResults.Rows.Count; i++)
                {
                    if ((bool)gridResults.Rows[i].Cells[0].Value == true)
                    {
                        ++counter;
                    }
                }
            }

            lblSelected.Text = Constants.SELECTED_PREFIX + counter.ToString();
        }

        private void gridResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            gridResults.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void gridResults_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            gridResults.Columns[0].Width = 50;
            gridResults.Columns[1].Width = 500;
            gridResults.Columns[2].Width = 600;
        }

        #endregion


        #region == EVENTS: SELECTORS ==

        /// <summary>
        /// Checks all results in the grid or tree
        /// </summary>
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (rbShowGrid.Checked)
            {
                SelectAllGridRows(true);
            }
            else
            {
                CheckAllTreeNodes(true);
            }
        }

        /// <summary>
        /// Unchecks all the results in the grid or tree
        /// </summary>
        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            if (rbShowGrid.Checked)
            {
                SelectAllGridRows(false);
            } else
            {
                CheckAllTreeNodes(false);
            }
        }


        private void btnInverse_Click(object sender, EventArgs e)
        {
            if (rbShowGrid.Checked)
            {
                InvertCheckedGridItems();
            }  
            else
            {
                InvertCheckedTreeNodes(tvResults.TopNode);
            }
        }

        #endregion

        
        #region == EVENTS: TREEVIEW ==

        /// <summary>
        /// Events that occur after a node is checked:
        ///     1. If node has children, check all children
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvResults_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // The code only executes if the user caused the checked state to change.
            if (e.Action != TreeViewAction.Unknown)
            {
                    if (e.Node.Nodes.Count > 0)
                    {
                        /* Calls the CheckAllChildNodes method, passing in the current 
                        Checked value of the TreeNode whose checked state changed. */
                        CheckAllChildNodes(e.Node, e.Node.Checked);
                    } 

                // Update the Selected label
                _selectedNodeCount = 0;
                CountCheckedNodes(tvResults.Nodes[0]);
                lblSelected.Text = Constants.SELECTED_PREFIX + _selectedNodeCount.ToString();

            }
        }

        private void tvResults_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageKey = "folderOpen";
            e.Node.SelectedImageKey = "folderOpen";

        }

        private void tvResults_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageKey = "folderClosed";
            e.Node.SelectedImageKey = "folderClosed";
        }

        #endregion

        #region == EVENTS: DISPLAY OPTIONS

        /// <summary>
        /// Events that occur when the Show Tree radio button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbShowTree_CheckedChanged(object sender, EventArgs e)
        {
            if (rbShowTree.Checked)
            {
                gridResults.Hide();
                tvResults.Show();

                DisplayTreeResults(_fileList);
            }
        }

        /// <summary>
        /// Events that occur whe the Show Grid radio button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            if (rbShowGrid.Checked)
            {
                tvResults.Hide();
                gridResults.Show();

                DisplayGridResults(_fileList);
            }
        }

        #endregion

        #region == DIALOG BOXES ==

        /// <summary>
        /// Save all the results of the scrape
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveFileDialogExportDetails_FileOk(object sender, CancelEventArgs e)
        {
            // Todo: Review the FoundFile class. It's tied to the grid and isn't as relevant anymore
            var foundFiles = new List<FoundFile>();

            foreach(string url in _fileList)
            {
                foundFiles.Add(new FoundFile
                {
                    Select = false,
                    Name = Processor.CleanseName(url),
                    Url = url
                });
            }

            // Save the baseUrl value in the file. This is useful when loading the file again.
            var baseUrl = tbUrl.Text;
            var output = String.Concat(baseUrl, ',', Serializer.Serialize(foundFiles));

            string filename = saveFileDialogExportDetails.FileName;

            File.WriteAllText(filename, output);
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var selectedUrls = "";

            if (rbShowGrid.Checked)
            {
                selectedUrls = GetSelectedGridUrls();
            }
            else
            {
                selectedUrls = GetSelectedTreeviewUrls(tvResults.Nodes);
            }

            string filename = saveFileDialog.FileName;
            File.WriteAllText(filename, selectedUrls);

        }

        /// <summary>
        /// Import a saved scrape
        /// </summary>
        private void openFileDialogImportDetails_FileOk(object sender, CancelEventArgs e)
        {

            var input = File.ReadAllText(openFileDialogImportDetails.FileName);

            if (input != String.Empty)
            {
                var baseUrl = input.Substring(0, input.IndexOf(','));
                tbUrl.Text = baseUrl;

                var files = input.Substring(input.IndexOf(',') + 1, input.Length - input.IndexOf(',') - 1);

                var foundFiles = new List<FoundFile>();
                foundFiles = Serializer.Deserialize<List<FoundFile>>(files);

                _fileList.Clear();
                foreach (var file in foundFiles)
                {
                    _fileList.Add(file.Url);
                }

                DisplayResults(_fileList);
            }


        }

        #endregion

        #region == HELPERS ==

        /// <summary>
        /// Displays the appropriate results view, depending on which Display Option is selected
        /// </summary>
        private void DisplayResults(List<string> fileList)
        {
            if (rbShowGrid.Checked)
            {
                gridResults.Show();
                tvResults.Hide();
                DisplayGridResults(fileList);
                _filteredList = fileList;

            }
            else
            {
                tvResults.Show();
                gridResults.Hide();
                DisplayTreeResults(fileList);
                _filteredList = fileList;

            }

        }

        /// <summary>
        /// Displays the results in a TreeView control
        /// </summary>
        /// <param name="fileList">List of Urls to be displayed</param>
        private void DisplayTreeResults(List<string> fileList)
        {
            // Refresh the tree each time it's rendered
            tvResults.Nodes.Clear();
            _selectedNodeCount = 0;

            // Display the top level node. Text is URL and value is URL
            var searchUrl = tbUrl.Text;
            var rootNode = tvResults.Nodes.Add(searchUrl, searchUrl);
            rootNode.ImageKey = "folderClosed";
            

            var fileCount = 0; // Keeps track of number of files added to the Treeview and displays in the UI

            foreach (var url in fileList)
            {
                // url should be valid because is was checked in GetUrls()
                // before being added to filteredList
                var uri = new Uri(url, UriKind.Absolute); 

                // Get the filename part of the url. We know all these urls have file names.
                var segments = uri.Segments;
                var fileName = segments[segments.Length - 1];

                // Get the url without the filename segment
                var fullPathNoFile = uri.AbsoluteUri.Remove(uri.AbsoluteUri.Length - uri.Segments.Last().Length);


                // This is the relative path to the file, but starting from the searchUrl.
                // This might be different from the file's actual relative Url, if the user didn't search from the site's root Url.
                var relativePathFromSearchUrl = uri.AbsoluteUri.Remove(0, searchUrl.Length);

                // Adding a slash to the full path, to make it easier for myself later
                fullPathNoFile = Processor.EnsureSlash(fullPathNoFile);

                // The TreeNode.Name property is used to store the unique paths to each file or folder.
                // This makes it possible to use the Find() function to see if a node already exists.
                // The TreeNode.Text propery is used to store the friendly name that is shown in the UI.
                var existingFolderNode = tvResults.Nodes.Find(fullPathNoFile, true).FirstOrDefault();

                // This must be a file in the root folder. Add it.
                if (existingFolderNode != null)
                {
                    var urlWithSlash = Processor.EnsureSlash(url);
                    var fileNode = existingFolderNode.Nodes.Add(url, Processor.CleanseName(url));
                    fileNode.ImageKey = "file";
                    fileNode.SelectedImageKey = "file";
                    fileCount++;
                }
                else
                {
                    // Get the relative folders, removing the file name, split them and then add them to a queue
                    var pathFolders = relativePathFromSearchUrl.Substring(0, relativePathFromSearchUrl.LastIndexOf('/'));
                    string[] folders = pathFolders.Split('/');
                    var queue = new Queue<string>(folders);

                    // These variables are used to store state between iterations of the While loop
                    var currentPath = searchUrl;
                    var currentNode = tvResults.Nodes[0];

                    while(queue.Count > 0)
                    {
                        // Get a folder off the queue
                        var searchNode = queue.Dequeue();
                        currentPath = Processor.EnsureSlash(currentPath + searchNode);

                        // Check if there's a folder node in the Treeview for this folder
                        var searchResult = tvResults.Nodes.Find(currentPath, true).FirstOrDefault();

                        // Node not found and there's more levels in the queue. Add a node for the folder,
                        // but don't add the file yet, because there's still more folders left in the queue
                        if (searchResult == null && queue.Count != 0)
                        {
                            currentNode = currentNode.Nodes.Add(currentPath, searchNode);
                            currentPath = currentNode.Name;
                        }
                        // Node not found and there's nothing left in the queue. This must be the last level of folders.
                        // So, add a node for the folder, then add the file to this node
                        else if (searchResult == null && queue.Count == 0)
                        {
                            currentNode = currentNode.Nodes.Add(currentPath, searchNode);
                            var fileNode = currentNode.Nodes.Add(url, Processor.CleanseName(url));
                            fileNode.ImageKey = "file";
                            fileNode.SelectedImageKey = "file";

                            fileCount++;
                        
                        // Node found and there's more levels in the queue. Need to keep processing through the queue
                        // Update the currentNode and currentPath, but don't add anything.
                        }
                        else if (searchResult != null && queue.Count != 0)
                        {
                            currentNode = searchResult;
                            currentPath = currentNode.Name;
                        }
                        else
                        {
                            // The node was found and there's nothing left in the queue. Add the file.
                            var fileNode = searchResult.Nodes.Add(url, Processor.CleanseName(url));
                            fileNode.ImageKey = "file";
                            fileNode.SelectedImageKey = "file";
                            fileCount++;
                        }
                    }
                }
            }

            tvResults.Sort();
            lblFileCount.Text = Constants.FILES_PREFIX + fileCount.ToString();
        }

        /// <summary>
        /// Display results in a table format
        /// </summary>
        /// <param name="fileList">List of Urls to be displayed</param>
        private void DisplayGridResults(List<string> fileList)
        {
            fileList.Sort();

            List<FoundFile> foundFiles = new List<FoundFile>();

            foreach (var url in fileList)
            {
                foundFiles.Add(new FoundFile
                {
                    Select = false, // grid automatically binds this to a checkbox
                    Name = Processor.CleanseName(url),
                    Url = url
                });
            }

            gridResults.DataSource = foundFiles;
            lblFileCount.Text = Constants.FILES_PREFIX + foundFiles.Count;
            lblSelected.Text = Constants.SELECTED_DEFAULT;
        }

        /// <summary>
        /// Iterates through the Treeview and gets the Urls of every node that is checked
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private string GetSelectedTreeviewUrls(TreeNodeCollection nodes)
        {

            foreach (TreeNode node in nodes)
            {
                // If Checked and doesn't have children, then it shoud be a file node (or an empty folder)
                // Return its name, which is the Url to the file
                if (node.Checked && node.Nodes.Count == 0)
                    _selectedTreeViewUrls += node.Name + Environment.NewLine;

                // Node has children. Must be a folder, so recurse until we hit a file
                if (node.Nodes.Count != 0)
                    GetSelectedTreeviewUrls(node.Nodes);
            }

            return _selectedTreeViewUrls;
        }

        /// <summary>
        /// Iterates through each row in the grid and returns all the Urls that were selected
        /// </summary>
        /// <returns>A string which contains Urls separated by a NewLine character</returns>
        private string GetSelectedGridUrls()
        {
            string selectedUrls = "";

            DataGridViewRowCollection rows = gridResults.Rows;

            for (int i = 0; i < rows.Count; i++)
            {
                if ((bool)rows[i].Cells[0].Value == true)
                {
                    selectedUrls += (rows[i].Cells[2].Value.ToString() + Environment.NewLine);
                }
            }

            return selectedUrls;
        }

        /// <summary>
        /// Updates all child nodes recursively
        /// </summary>
        /// <param name="treeNode">A single node in a Treeview</param>
        /// <param name="nodeChecked">True if node was seclted, false if not</param>
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        private void CountCheckedNodes(TreeNode node)
        {
                if (node.Nodes.Count == 0) {
                    if (node.Checked) _selectedNodeCount++;
                }
                else
                {
                foreach (TreeNode childNode in node.Nodes)
                {
                    CountCheckedNodes(childNode);

                }
            }
        }

        /// <summary>
        /// Checks/unchecks all the rows in a grid.
        /// </summary>
        /// <param name="outcome">True to check; false to uncheck</param>
        private void SelectAllGridRows(bool outcome)
        {
            if (gridResults.Rows.Count > 0)
            {
                for (int i = 0; i < gridResults.Rows.Count; i++)
                {
                    gridResults.Rows[i].Cells[0].Value = outcome;
                }
            }
        }

        /// <summary>
        /// Checks all the nodes in a Treeview
        /// </summary>
        /// <param name="outome">True to check; false to uncheck</param>
        private void CheckAllTreeNodes(bool outcome)
        {
            CheckAllChildNodes(tvResults.TopNode, outcome);
        }


        private void InvertCheckedGridItems()
        {
            if (gridResults.Rows.Count > 0)
            {
                for (int i = 0; i < gridResults.Rows.Count; i++)
                {
                    gridResults.Rows[i].Cells[0].Value = !(bool)(gridResults.Rows[i].Cells[0].Value);
                }
            }
        }

        private void InvertCheckedTreeNodes(TreeNode treeNode)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = !node.Checked;
                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                    this.InvertCheckedTreeNodes(node);
                }
            }
        }

        #endregion

    }
}
