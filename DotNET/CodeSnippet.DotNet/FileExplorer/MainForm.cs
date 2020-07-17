using System;
using System.IO;
using System.Windows.Forms;

namespace FileExplorer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Application Controls

        private void MainForm_Shown(object sender, EventArgs e)
        {
            PopulateTreeView();
        }

        #endregion

        #region Event Handlers

        private void treeViewFolders_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;

            this.listViewFileList.Items.Clear();
            ClearFileImageListExceptFolderIcon();

            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;

            if (nodeDirInfo == null)
                return;

            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
            {
                if (dir.Attributes.HasFlag(FileAttributes.System) || dir.Attributes.HasFlag(FileAttributes.Hidden))
                    continue;

                item = new ListViewItem(dir.Name, this.fileImageList.Images.Count - 1);
                subItems = new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(item, "Directory"),
                                                                new ListViewItem.ListViewSubItem(item, dir.LastAccessTime.ToShortDateString())};
                item.SubItems.AddRange(subItems);
                this.listViewFileList.Items.Add(item);
            }

            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                if (file.Attributes.HasFlag(FileAttributes.System) || file.Attributes.HasFlag(FileAttributes.Hidden))
                    continue;

                this.fileImageList.Images.Add(System.Drawing.Icon.ExtractAssociatedIcon(file.FullName));

                item = new ListViewItem(file.Name, this.fileImageList.Images.Count - 1);
                subItems = new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(item, "File"),
                                                                new ListViewItem.ListViewSubItem(item, file.LastAccessTime.ToShortDateString())};

                item.SubItems.AddRange(subItems);
                this.listViewFileList.Items.Add(item);
            }

            this.listViewFileList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void treeViewFolders_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode expandingNode = e.Node;
            DirectoryInfo nodeDirInfo = (DirectoryInfo)expandingNode.Tag;

            if (nodeDirInfo == null)
                return;

            GetDirectories(nodeDirInfo, expandingNode);
        }

        #endregion

        #region Private Methods

        private void PopulateTreeView()
        {
            int imageIndex = this.folderImageList.Images.IndexOfKey("Computer");
            TreeNode rootNode = new TreeNode("My Computer", imageIndex, imageIndex);
            this.treeViewFolders.Nodes.Add(rootNode);

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                imageIndex = GetDriveImageIndex(drive);
                TreeNode driveNode = new TreeNode(drive.Name, imageIndex, imageIndex);
                driveNode.Tag = drive.RootDirectory;
                driveNode.Nodes.Add("Dummy");

                rootNode.Nodes.Add(driveNode);
            }
        }

        private void GetDirectories(DirectoryInfo expandingFolder, TreeNode nodeToAddTo)
        {
            int imageIndex = this.folderImageList.Images.IndexOfKey("Folder");

            try
            {
                nodeToAddTo.Nodes.Clear();

                foreach (DirectoryInfo subFolder in expandingFolder.GetDirectories())
                {
                    if (subFolder.Attributes.HasFlag(FileAttributes.System) || subFolder.Attributes.HasFlag(FileAttributes.Hidden))
                        continue;

                    TreeNode subFolderNode = new TreeNode(subFolder.Name, imageIndex, imageIndex);
                    subFolderNode.Tag = subFolder;
                    subFolderNode.Nodes.Add("Dummy");

                    nodeToAddTo.Nodes.Add(subFolderNode);
                }
            }
            catch (Exception)
            {
            }
        }

        private int GetDriveImageIndex(DriveInfo drive)
        {
            int imageIndex = 0;

            switch (drive.DriveType)
            {
                case DriveType.Removable:
                    imageIndex = this.folderImageList.Images.IndexOfKey("RemovableDrive");
                    break;

                case DriveType.Fixed:
                    imageIndex = this.folderImageList.Images.IndexOfKey("HardDiskDrive");
                    break;

                case DriveType.Network:
                    imageIndex = this.folderImageList.Images.IndexOfKey("NetworkDrive");
                    break;

                case DriveType.CDRom:
                    imageIndex = this.folderImageList.Images.IndexOfKey("CDDrive");
                    break;

                default:
                    imageIndex = this.folderImageList.Images.IndexOfKey("Folder");
                    break;
            }

            if (imageIndex < 0)
                imageIndex = 0;

            return imageIndex;
        }

        private void ClearFileImageListExceptFolderIcon()
        {
            int imageIndex = this.fileImageList.Images.Count - 1;

            for (int index = imageIndex; index > 0; index--)
            {
                this.fileImageList.Images.RemoveAt(index);
            }
        }

        #endregion
    }
}
